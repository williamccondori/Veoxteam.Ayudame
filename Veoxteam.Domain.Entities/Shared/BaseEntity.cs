using System;

namespace Veoxteam.Domain.Entities.Shared
{
    public class BaseEntity
    {
        public string StatusIndicator { get; set; }
        public string UserAdd { get; set; }
        public string UserEdit { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateEdit { get; set; }
        public ObjectStatus ObjectEstatus { get; set; }
    }
}
