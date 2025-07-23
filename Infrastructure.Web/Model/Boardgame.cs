using System;

namespace Demant.Interview.Infrastructure.Web.Model
{
    public class Boardgame
    {
        public string Name { get; set; }
        public string BorrowedBy { get; set; }
        public DateTime? BorrowedUntil { get; set; }
    }
}