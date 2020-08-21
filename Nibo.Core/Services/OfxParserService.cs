using Microsoft.AspNetCore.Http;
using Nibo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nibo.Core.Services
{
    public class OfxParserService<T> : IOfxParserService<ICollection<Conciliation>>
    {
        public async Task<ICollection<Conciliation>> Parse(IEnumerable<IFormFile> files)
        {
            var text = string.Empty;
            var conciliation = new Conciliation();
            ICollection<Conciliation> conciliations = new List<Conciliation>();

            files.ToList().ForEach(file =>
            {
                using (var stream = file.OpenReadStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();

                            if (line.Contains("<STMTTRN>")) conciliation = new Conciliation();

                            if (line.Contains("<TRNTYPE>"))
                                conciliation.TransactionType = line.Substring("<TRNTYPE>".Length).Equals("DEBIT") ? Core.Enums.TransactionTypeEnum.DEBIT : Core.Enums.TransactionTypeEnum.CREDIT;

                            if (line.Contains("<DTPOSTED>"))
                            {
                                var date = line.Substring("<DTPOSTED>".Length);
                                conciliation.DatePosted = new DateTime(int.Parse(date.Substring(0, 4)),
                                                                     int.Parse(date.Substring(4, 2)),
                                                                     int.Parse(date.Substring(6, 2))
                                                                     );
                            }

                            if (line.Contains("<TRNAMT>"))
                            {
                                var amountAsString = line.Substring("<TRNAMT>".Length);
                                var amountAsDouble = double.Parse(amountAsString);
                                conciliation.TransactionAmount = amountAsDouble;
                            }

                            if (line.Contains("<MEMO>"))
                            {
                                var description = line.Substring("<MEMO>".Length);
                                conciliation.TransactionDescription = description;
                            }

                            if (line.Contains("</STMTTRN>"))
                                conciliations.Add(conciliation);
                        }
                    }
                }
            });

            return await Task.FromResult(conciliations);
        }
    }
}
