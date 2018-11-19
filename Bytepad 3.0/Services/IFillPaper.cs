using System.Collections.Generic;
using System.Web;

namespace Bytepad_3._0.Models
{
    public interface IFillPaper
    {
        void FilledPapers(Paper objPaper, List<HttpPostedFileBase> ListOfPapers, out List<string> listOfRejectedFiles);
    }
}