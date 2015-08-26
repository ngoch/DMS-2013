using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DMS.Infrastructure
{
    public class FilterDefinitionBase
    {
        public string SearchQuery { get; set; }
        private bool? _isDefined { get; set; }

        public virtual IEnumerable<PropertyInfo> GetPropertiesForCheck()
        {
            return this.GetType().GetProperties();
        }

        public virtual bool IsDefined()
        {
            if (!(_isDefined.HasValue))
            {
                _isDefined = false;

                foreach (var item in GetPropertiesForCheck())
                {
                    object value = item.GetValue(this, null);

                    if (value != null)
                    {
                        if (item.PropertyType == typeof(string))
                        {
                            if (!string.IsNullOrWhiteSpace((string)value))
                            {
                                _isDefined = true;
                                break;
                            }
                        }
                        else if (item.PropertyType.GetInterface(typeof(IEnumerable).Name) != null)
                        {
                            if (((IEnumerable)value).GetEnumerator().MoveNext())
                            {
                                _isDefined = true;
                                break;
                            }
                        }
                        else if (item.PropertyType.Equals(typeof(UnboundedPeriod)))
                        {
                            UnboundedPeriod period = (UnboundedPeriod)value;

                            if (period.StartDate.HasValue || period.EndDate.HasValue)
                            {
                                _isDefined = true;
                                break;
                            }
                        }
                        else
                        {
                            _isDefined = true;
                            break;
                        }
                    }
                }
            }

            return _isDefined.Value;
        }
    }
}
