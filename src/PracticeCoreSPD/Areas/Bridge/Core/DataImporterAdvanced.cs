using System;
using System.Collections.Generic;

namespace PracticeCoreSPD.Areas.Bridge.Core
{
    public class DataImporterAdvanced : IDataImporter
    {
        public IErrorLogger ErrorLogger { get; set; }

        public void Import(List<Customer> data)
        {
            using (AppDbCustomer db = new AppDbCustomer())
            {
                try
                {
                    foreach (var item in data)
                    {
                        db.Customers.Add(item);
                    }
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    ErrorLogger.Log(ex.Message);
                }
            }
        }
    }
}
