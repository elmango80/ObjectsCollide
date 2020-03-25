using System;

using ObjectsCollide.Application.Enums;

using NGenerics.DataStructures.Mathematical;

namespace ObjectsCollide.Application.Class
{
    public class Cube : Object3D
    {
        internal readonly double Dimensions;
        internal readonly Vector2D XAxis;

        public Cube(double dimension, double x, double y, double z) : base(Object3DTypes.Cube, x, y, z)
        {
            Dimensions = dimension;
            XAxis = new Vector2D(x - dimension / 2, x + dimension / 2);
        }

        public override bool CollidesWith(Object3D thatObject)
        {
            if (thatObject == null)
                throw new ArgumentNullException();

            switch (thatObject.Type)
            {
                case Object3DTypes.Cube:
                    return CollidesWithCube((Cube)thatObject);
                case Object3DTypes.Coboid:
                    throw new NotImplementedException();
                default:
                    return CollidesWithCube((Cube)thatObject);
            }
        }

        public override double IntersectedVolume(Object3D thatObject)
        {
            if (thatObject == null)
                throw new ArgumentNullException();

            if (!CollidesWith(thatObject))
                return default;

            switch (thatObject.Type)
            {
                case Object3DTypes.Cube:
                    return ResolveVolumeIntersectionWithCube((Cube)thatObject);
                case Object3DTypes.Coboid:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
        internal override double Volume()
        {
            return Math.Pow(Dimensions, 3);
        }

        private bool CollidesWithCube(Cube thatCube)
        {
            if (thatCube == null)
                throw new ArgumentNullException();

            if (XAxis.Minimum() > thatCube.XAxis.Maximum())
                return false;

            if (XAxis.Maximum() < thatCube.XAxis.Minimum())
                return false;

            return true;
        }

        private double ResolveVolumeIntersectionWithCube(Cube thatCube)
        {
            if (thatCube == null)
                throw new ArgumentNullException();

            double width, height, depth;

            if (XAxis.Maximum() <= thatCube.XAxis.Maximum())
                width = XAxis.Maximum() - thatCube.XAxis.Minimum();
            else
            {
                if (XAxis.Maximum() >= thatCube.XAxis.Maximum())
                    width = thatCube.XAxis.Maximum() - XAxis.Minimum();
                else
                    width = XAxis.Maximum() - thatCube.XAxis.Minimum();
            }

            height = thatCube.Dimensions <= Dimensions ? thatCube.Dimensions : Dimensions;
            depth = thatCube.Dimensions <= Dimensions ? thatCube.Dimensions : Dimensions;

            var resultCoboid = new Coboid(width, height, depth, width / 2, height / 2, depth / 2);

            return resultCoboid.Volume();
        }
    }
}
