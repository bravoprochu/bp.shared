using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bp.shared.DocumentNumbers
{
    public partial class DocNumber
    {
        public DocNumberDTO GenNumberMonthYearFormat(string LastDocNumber, DateTime date, char separator = '/')
        {
            var lastDoc = this.ParseDocNumber(LastDocNumber, date, separator);
            return this.NextNumber(lastDoc, date);
        }

        public DocNumberDTO GenNumberYearFormat(string lastDocNumber, DateTime date, char separator = '/')
        {
            return new DocNumberDTO();
        }

        private DocNumberDTO ParseDocNumber(string actDocNo, DateTime initDate, char separator = '/')
        {

            var res = new DocNumberDTO(separator);

            if (string.IsNullOrWhiteSpace(actDocNo)) return this.ZeroDocNumber(res, initDate);

            var arr = actDocNo.Split(separator).Reverse().ToArray();
            int arrCount = arr.Length > 3 ? 1 : 0;

            if (arr.Length == 0)
            {
                return this.ZeroDocNumber(res, initDate);
            }

            var lastArrEl = arr[arr.Length - 1];
            //if last array's element (lastArrEl) can not be parsed (prefixInt==-1) - it means it is a string = prefix !
            int prefixInt = -1;
            bool isPrefix= !int.TryParse(lastArrEl, out prefixInt);

            if (isPrefix)
            {
                res.Prefix = lastArrEl;
            };


            //string prefix = arr.Length > 3 ? arr[0] : null;

            //int no = 0;
            int year = 0;
            bool resYear = Int32.TryParse(arr[0], out year);
            res.DocYear = year;

            if (isPrefix)
            {
                if (arr.Length == 4)
                {
                    int month = 0;
                    Int32.TryParse(arr[1], out month);
                    res.DocMonth = month;
                    int no = 0;
                    Int32.TryParse(arr[2], out no);
                    res.DocNumber = no;
                }
                else
                {
                    res.DocMonth = 0;
                    int no = 0;
                    Int32.TryParse(arr[1], out no);
                    res.DocNumber = no;
                }
            }
            else {
                if (arr.Length == 3)
                {
                    int month = 0;
                    Int32.TryParse(arr[1], out month);
                    res.DocMonth = month;
                    int no = 0;
                    Int32.TryParse(arr[2], out no);
                    res.DocNumber = no;
                }
                else {
                    res.DocMonth = 0;
                    int no = 0;
                    Int32.TryParse(arr[1], out no);
                    res.DocNumber = no;
                }
            }




            //bool resNo = Int32.TryParse(arr[0 + arrCount], out no);
            //int month = 0;
            //bool resMonth = Int32.TryParse(arr[1 + arrCount], out month);
            

            //if (resNo && resMonth && resYear)
            //{
            //    res.DocNumber = no;
            //    res.DocMonth = month;
            //    res.Prefix = prefix;
            //    res.DocYear = year;
            //}

            return res;
        }

        private DocNumberDTO ZeroDocNumber(DocNumberDTO res, DateTime initDate)
        {
            res.DocNumber = 0;
            res.DocMonth = initDate.Month;
            res.DocYear = initDate.Year;

            return res;
        }

        private DocNumberDTO NextNumber(DocNumberDTO res, DateTime date)
        {
            //date from UTC 
            date = date.ToLocalTime();

            //next yaar
            if (res.DocYear < date.Year)
            {
                res.DocMonth = 1;
                res.DocNumber = 1;
                res.DocYear = date.Year;
                return res;
            }
            //next month
            if (res.DocMonth>0 && (res.DocMonth < date.Month))
            {
                res.DocMonth = date.Month;
                //res.DocNumber = 1;
                res.DocNumber++;
                return res;
            }
            res.DocNumber++;
            return res;
        }

    }
}
