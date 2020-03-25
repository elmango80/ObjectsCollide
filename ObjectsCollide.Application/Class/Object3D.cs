using NGenerics.DataStructures.Mathematical;

using ObjectsCollide.Application.Enums;

namespace ObjectsCollide.Application.Class
{
    public abstract class Object3D
    {
        protected internal readonly Vector3D Center;

        protected internal readonly Object3DTypes Type;

        public Object3D(Object3DTypes type, double x, double y, double z)
        {
            Type = type;
            Center = new Vector3D(x, y, z);
        }

        public abstract bool CollidesWith(Object3D thatObject);

        public abstract double IntersectedVolume(Object3D thatObject);

        internal abstract double Volume();
    }
}
