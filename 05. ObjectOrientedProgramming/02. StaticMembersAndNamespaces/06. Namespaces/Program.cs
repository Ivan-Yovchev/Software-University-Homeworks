﻿using System;
using Geometry.Geometry2D;
using Geometry.Geometry3D;
using Geometry.Storage;
using Geometry.UI;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            DistanceCalculator2D dist = new DistanceCalculator2D();
            Elipse elipse = new Elipse();
            Figure2D figure = new Figure2D();
            Point2D point = new Point2D();
            Polygon plygon = new Polygon();
            Rectangle rectangle = new Rectangle();
            Square square = new Square();

            Console.WriteLine();

            Point3D point3D = new Point3D();
            Path3D path = new Path3D();
            DistanceCalculator3D dist3D = new DistanceCalculator3D();

            Console.WriteLine();

            GeometryBinaryStorage gbStorage = new GeometryBinaryStorage();
            GeometrySVGStorage gsStorage = new GeometrySVGStorage();
            GeometryXMLStorage gxStorage = new GeometryXMLStorage();

            Console.WriteLine();

            Screen2D sc2D = new Screen2D();
            Screen3D sc3D = new Screen3D();
        }
    }
}