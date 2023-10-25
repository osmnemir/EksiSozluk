﻿using EksiSozluk.Api.Domain.Models;
using EksiSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Infrastructure.Persistence.EntityConfigurations
{
    public class EmailConfirmationEntityConfiguraiton : BaseEntityConfiguration<EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);
            builder.ToTable("emailconfirmation", EksiSozlukContext.DEFAULT_SCHEMA);

            

        }
    }
}
