using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class SQLSaver : ISaver
    {
        public void Save(ListOfEquations list)
        {
            using (SQLManager db = new SQLManager())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                foreach (Equation eq in list.EqList)
                {
                    db.EqList.Add(eq);
                }
                db.SaveChanges();
            }
        }
    }
}
