using System;

using NGenerics.DataStructures.Mathematical;

using ObjectsCollide.Application.Enums;

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
            throw new NotImplementedException();
        }

        public override double IntersectedVolume(Object3D thatObject)
        {
            throw new NotImplementedException();
        }

        internal override double Volume()
        {
            throw new NotImplementedException();
        }
    }
}
