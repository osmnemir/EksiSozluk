﻿using EksiSozluk.Api.Domain.Models;
using EksiSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Infrastructure.Persistence.EntityConfigurations.EntryComment
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);
            builder.ToTable("entrycommentvote", EksiSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.EntryComment)
                .WithMany(i => i.EntryCommentVotes)
                .HasForeignKey(i => i.EntryCommentId);

            

        }
    }
}
