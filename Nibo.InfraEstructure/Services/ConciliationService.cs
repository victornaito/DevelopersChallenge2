﻿using Microsoft.AspNetCore.Http;
using Nibo.Core;
using Nibo.Core.Dtos;
using Nibo.Core.Enums;
using Nibo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nibo.InfraEstructure.Services
{
    public class ConciliationService
    {
        private readonly IOfxParserService<ICollection<Conciliation>> _ofxParserService;
        private readonly Context _context;

        public ConciliationService(IOfxParserService<ICollection<Conciliation>> ofxParserService, Context context)
        {
            _ofxParserService = ofxParserService;
            this._context = context;
        }

        public async Task<IEnumerable<AmountTransationalDto>> Process(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return null;

            _context.Set<Conciliation>().RemoveRange(_context.Set<Conciliation>().ToList());

            IEnumerable<Conciliation> conciliations = await _ofxParserService.Parse(files);
            var conciliationsDto = conciliations.GroupBy(s => s.DatePosted).Select(s => new AmountTransationalDto
            {
                DatePosted = s.Key,
                TransactionAmount = Math.Round(s.Sum(d => d.TransactionAmount), 2),
                OperationDescription = s.FirstOrDefault().TransactionDescription.Trim(),
                TransactionType = s.FirstOrDefault().TransactionType,
                TransactionTypeDescription = s.FirstOrDefault().TransactionType.Equals(TransactionTypeEnum.CREDIT) ? "Crédito" : "Débito"
            })
            .OrderBy(_ => _.DatePosted);

            await _context.AddRangeAsync(conciliations);
            await _context.SaveChangesAsync();

            return conciliationsDto;
        }
    }
}
