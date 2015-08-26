using DMS.Domain.Fuzzy.Aggregation;
using DMS.Fuzzy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Fuzzy.Aggregation
{
    public static class AggregationFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">MIN,MAX,AVERAGE</param>
        /// <returns></returns>
        public static IAggregation CreateSimpleAggregation(AggregationType type)
        {
            IAggregation aggregation = null;

            switch (type)
            {
                case AggregationType.MIN:
                    {
                        aggregation = new Min();
                        break;
                    }
                case AggregationType.MAX:
                    {
                        aggregation = new Max();
                        break;
                    }
                case AggregationType.AVERAGE:
                    {
                        aggregation = new Average();
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Not supported yet.");
                    }
            }
            return aggregation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">OWA,OWG</param>
        /// <param name="weights">required</param>
        /// <returns></returns>
        public static IAggregation CreateWeightAggregation(AggregationType type, List<decimal> weights)
        {
            IAggregation aggregation = null;

            switch (type)
            {
                case AggregationType.OWA:
                    {
                        aggregation = new OWA(weights);
                        break;
                    }
                case AggregationType.OWG:
                    {
                        aggregation = new OWG(weights);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Not supported yet.");
                    }
            }
            return aggregation;
        }

        /// <summary>
        ///  Aggregations: 
        ///    GOWA    - aditional parameters [alfa] 
        ///    POWA    - aditional parameters [beta, points]
        ///    IOWA    - aditional parameters [ratings] 
        ///    IGOWA   - aditional parameters [ratings, alfa] 
        ///    IOWG    - aditional parameters [ratings] 
        ///   ASPOWA  - aditional parameters [probability]
        /// Necessary parameter: weights
        /// </summary>
        /// <param name="type"></param>
        /// <param name="weights"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IAggregation CreateParamAggregation(AggregationType type, List<decimal> weights, params Object[] param)
        {
            IAggregation aggregation = null;

            switch (type)
            {
                case AggregationType.GOWA:
                    {
                        if (param[0] is decimal)
                        {
                            decimal p = (decimal)param[0];
                            aggregation = new GOWA(weights, p);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }
                case AggregationType.POWA:
                    {
                        if ((param.Length == 2) && (param[0] is List<decimal>) && (param[1] is decimal))
                        {
                            List<decimal> p = (List<decimal>)param[0];
                            decimal beta = (decimal)param[1];
                            aggregation = new POWA(weights, p, beta);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }
                case AggregationType.IOWA:
                    {
                        if (param[0] is List<decimal>)
                        {
                            List<decimal> p = (List<decimal>)param[0];

                            IOWA iowa = new IOWA(weights);
                            iowa.Ratings = p;
                            aggregation = iowa;
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }

                case AggregationType.IGOWA:
                    {
                        if ((param.Length == 2) && (param[0] is List<decimal>) && (param[1] is decimal))
                        {
                            List<decimal> rating = (List<decimal>)param[0];
                            decimal p = (decimal)param[1];
                            IGOWA igowa = new IGOWA(weights, p);
                            igowa.Ratings = rating;
                            aggregation = igowa;
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }
                case AggregationType.IOWG:
                    {
                        if ((param.Length == 1) && (param[0] is List<decimal>))
                        {
                            List<decimal> rating = (List<decimal>)param[0];
                            IOWG iowg = new IOWG(weights);
                            iowg.Ratings = rating;
                            aggregation = (IOWG)iowg;
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }
                case AggregationType.ASPOWA_MIN:
                    {
                        if (param[0] is List<decimal>)
                        {
                            List<decimal> p = (List<decimal>)param[0];
                            aggregation = new ASPOWA(weights, p, (decimal)param[1], AggregationType.ASPOWA_MIN);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }
                case AggregationType.ASPOWA_MAX:
                    {
                        if (param[0] is List<decimal>)
                        {
                            List<decimal> p = (List<decimal>)param[0];
                            aggregation = new ASPOWA(weights, p, (decimal)param[1], AggregationType.ASPOWA_MAX);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }
                case AggregationType.ASPOWA_MEAN:
                    {
                        if (param[0] is List<decimal>)
                        {
                            List<decimal> p = (List<decimal>)param[0];
                            aggregation = new ASPOWA(weights, p, (decimal)param[1], AggregationType.ASPOWA_MEAN);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Parameter");
                        }
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Not supported yet.");
                    }
            }
            return aggregation;
        }
    }
}