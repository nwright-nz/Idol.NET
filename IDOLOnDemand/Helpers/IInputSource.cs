using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Helpers
{
    public interface IInputSource

    {
        string Key { get; }
        string Value { get; }
    }

    public class JsonInputSource : IInputSource
    {
        private readonly string _s;

        public JsonInputSource(string s)
        {
            _s = s;
        }


        public string Key
        {
            get { return "Json"; }
        }

        public string Value
        {
            get { return _s; }
        }
    }

    public class FileInputSource : IInputSource
    {
        private readonly string _filePath;

        public FileInputSource(string filePath)
        {
            _filePath = filePath;
        }

        public string Key
        {
            get { return "File"; }
        }

        public string Value
        {
            get { return _filePath; }
        }
    }

    public class UrlInputSource : IInputSource
    {
        private readonly Uri _uri;

        public UrlInputSource(Uri uri)
        {
            _uri = uri;
        }

        public string Key
        {
            get { return "Uri"; }
        }

        public string Value
        {
            get { return _uri.ToString(); }
        }
    }
}
