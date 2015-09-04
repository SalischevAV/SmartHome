using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refrigerator
{
    public interface IValueControl
    {
        void NextValue();

        void PreviosValue();

        void SetValue(int needValue);
    }
}
