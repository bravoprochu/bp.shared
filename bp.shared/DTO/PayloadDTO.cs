using System;
using System.Collections.Generic;
using System.Net;
using System.Text;



namespace bp.shared.DTO
{
    public class PayloadDTO<T> where T : class
    {


        private List<T> _dataList { get; set; }
        private List<string> _errorList { get; set; }
        private int? _httpStatusCode {get;set;}

        public PayloadDTO()
        {
            this._dataList = new List<T>();
            this._errorList = new List<string>();
        }
        //public PayloadDTO(T data)
        //{
        //    this._dataList = new List<T>();
        //    this._dataList.Add(data);
        //}
        //public PayloadDTO(List<T> dataList)
        //{
        //    this._dataList = dataList;
        //}
        //public PayloadDTO(string errorInfo)
        //{
        //    this._errorList = new List<string>();
        //    this._errorList.Add(errorInfo);
        //}
        //public PayloadDTO(List<string> errorInfoList) {
        //    this._errorList = errorInfoList;
        //}

        public void AddErrorInfo(string errorInfo) {
            this._errorList.Add(errorInfo);
        }
        public void AddErrorInfo(string errorInfo, HttpStatusCode httpStatusCode)
        {
            this._errorList.Add(errorInfo);
            this.HttpStatusCode = (int)httpStatusCode;
        }
        public void AddErrorInfo(List<string> errorList) => this._errorList = errorList;
        public void AddData(T data) => this._dataList.Add(data);
        public void AddData(List<T> dataList) => this._dataList = dataList;
        public int DataCount => this._dataList.Count;
        public int ErrorCount => this._errorList.Count;
                
        public string Info { get; set; }
        public List<string> GetError => this._errorList;
        public List<T> GetData => this._dataList;
        public int HttpStatusCode { get {
                return this._httpStatusCode.HasValue ? this._httpStatusCode.Value: 200;
            } set {
                this._httpStatusCode = value;
            } }
        
    }
}
