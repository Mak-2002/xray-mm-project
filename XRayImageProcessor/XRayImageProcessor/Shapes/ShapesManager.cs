using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace XRayImageProcessor.Shapes
{
    public abstract class Shape
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public abstract void Draw(Graphics g);
    }

    public class RectangleShape : Shape
    {
        public override void Draw(Graphics g)
        {
            Rectangle rect = new Rectangle(Math.Min(StartPoint.X, EndPoint.X), Math.Min(StartPoint.Y, EndPoint.Y),
                                           Math.Abs(StartPoint.X - EndPoint.X), Math.Abs(StartPoint.Y - EndPoint.Y));
            g.DrawRectangle(Pens.Red, rect);
        }
    }

    public class TriangleShape : Shape
    {
        public override void Draw(Graphics g)
        {
            Point[] points = { StartPoint, new Point((StartPoint.X + EndPoint.X) / 2, EndPoint.Y), EndPoint };
            g.DrawPolygon(Pens.Green, points);
        }
    }

    public class CurveShape : Shape
    {
        public List<Point> Points { get; set; } = new List<Point>();

        public override void Draw(Graphics g)
        {
            if (Points.Count > 1)
            {
                g.DrawCurve(Pens.Blue, Points.ToArray());
            }
        }
    }

    public class ArrowShape : Shape
    {
        public override void Draw(Graphics g)
        {
            AdjustableArrowCap arrowCap = new AdjustableArrowCap(5, 5);
            Pen pen = new Pen(Color.Black, 2) { CustomEndCap = arrowCap };
            g.DrawLine(pen, StartPoint, EndPoint);
        }
    }

    public class ShapeManager
    {
        private List<Shape> shapes = new List<Shape>();
        private Shape currentShape;

        public void StartShape(Shape shape, Point startPoint)
        {
            currentShape = shape;
            currentShape.StartPoint = startPoint;
        }

        public void UpdateShape(Point endPoint)
        {
            if (currentShape != null)
            {
                currentShape.EndPoint = endPoint;
                if (currentShape is CurveShape curveShape)
                {
                    curveShape.Points.Add(endPoint);
                }
            }
        }

        public void FinishShape()
        {
            if (currentShape != null)
            {
                shapes.Add(currentShape);
                currentShape = null;
            }
        }

        public void DrawShapes(Graphics g)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }

            currentShape?.Draw(g);
        }
    }
}
