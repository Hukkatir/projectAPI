﻿using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ICommentRepository Comment { get; }
        ICommentRateRepository CommentRate { get; }
        IContentRepository Content { get; }
        IFileRepository Files { get; }
        IMediaFileRepository MediaFile { get; }
        IMediumRepository Medium { get; }
        IMessagesUserRepository MessagesUser { get; }
        IMyRatingRepository MyRating { get; }
        IPaymentRepository Payment { get; }
        IPaymentUserRepository PaymentUser { get; }
        IRoomRepository Room { get; }
        IRoomsUserRepository RoomsUser { get; }
        IGroupMediumRepository GroupMedium { get; }
        void Save();

    }
}
