using System.Collections.Generic;

namespace PracticeCoreSPD.Areas.Bridge.Core
{
    public interface IDataImporter
    {
        IErrorLogger ErrorLogger { get; set; }
        void Import(List<Customer> data);
    }
}
