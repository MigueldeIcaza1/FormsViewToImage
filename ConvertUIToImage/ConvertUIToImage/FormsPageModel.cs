using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertUIToImage
{
    public class FormsPageModel
    {
        public ObservableCollection<CategoricalData> Data { get; set; }

        public FormsPageModel()
        {
            Data = new ObservableCollection<CategoricalData>();
            LoadData();
        }
        private void LoadData()
        {

            Data.Add(new CategoricalData { Category = "Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "EVAC Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "Power Status-OtherThanNormal", Value = 0 });
            Data.Add(new CategoricalData { Category = "Non Compliance", Value = 148 });

            Data.Add(new CategoricalData { Category = "Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "EVAC Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "Power Status-OtherThanNormal", Value = 0 });
            Data.Add(new CategoricalData { Category = "Non Compliance", Value = 148 });

            Data.Add(new CategoricalData { Category = "Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "EVAC Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "Power Status-OtherThanNormal", Value = 0 });
            Data.Add(new CategoricalData { Category = "Non Compliance", Value = 148 });

            Data.Add(new CategoricalData { Category = "Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "EVAC Status-OtherThanNormal", Value = 2 });
            Data.Add(new CategoricalData { Category = "Power Status-OtherThanNormal", Value = 0 });
            Data.Add(new CategoricalData { Category = "Non Compliance", Value = 148 });

        }
    }

    public class CategoricalData
    {
        public string Category { get; set; }
        public double Value { get; set; }
    }
}
