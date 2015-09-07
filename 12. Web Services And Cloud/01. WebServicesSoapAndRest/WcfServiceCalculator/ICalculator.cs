using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceCalculator
{
    [ServiceContract]
    public interface ICalculator
    {

        [OperationContract]
        double CalcDistance(Point startPoint, Point endPoint);
    }

    [DataContract]
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }
    }
}
