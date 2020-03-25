using System;

using ObjectsCollide.Application.Enums;

namespace ObjectsCollide.Application.Class
{
    internal class Coboid : Object3D
    {
        internal readonly double Depth;
        internal readonly double Height;
        internal readonly double Width;

        public Coboid(double width, double height, double depth, double x, double y, double z)
            : base(Object3DTypes.Coboid, x, y, z)
        {
            Width = width;
            Height = height;
            Depth = depth;
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
            return Width * Height * Depth;
        }
    }
}