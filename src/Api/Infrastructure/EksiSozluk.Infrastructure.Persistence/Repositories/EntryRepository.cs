using EksiSozluk.Api.Aplication.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Models;
using EksiSozluk.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Infrastructure.Persistence.Repositories
{
    public class EntryRepository:GenericRepository<Entry>, IEntryRepository
{
    public EntryRepository(EksiSozlukContext dbContext) : base(dbContext)
    {
    }
}
}
