using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class DaoReservation
    {
        private Dbal _dbal;

        public DaoReservation(Dbal dbal)
        {
            this._dbal = dbal;
        }
    }
}
