using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    /// <summary>
    /// Пример модели данных
    /// </summary>
    public class DataModel
    {
        private int[] data;

        public delegate void DataDelegate(object sender, int index, int data);
        public event DataDelegate DataChanged;
    }
}
