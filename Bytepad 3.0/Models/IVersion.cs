using System;

namespace Bytepad_3._0.Models
{
    public interface IVersion
    {
        int ID { get; set; }
        DateTime LastAddPaperTime { get; set; }

        DateTime? getLastAddPaperTime();
        void updateLastAddPaperTime();
    }
}