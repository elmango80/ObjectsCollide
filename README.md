# Cube Intersection

Design and start and application (or test project) which accepts as input dimensions and coordinates of two cubic objects (considering a 3D space). The application must determine whether the two objects collide and calculate the intersected volume.
It's not a math exercise, so it is acceptable to consider the two cubes are parallel, so there is no rotation among themselves.
The input coordinates define the center of the cube.
The purpose of this exercise is to define the application design and architecture, focusing on the parts which ensure the correctness, performance and code clarity. Any design pattern is accepted and should be justified.


## Object3D Abstract Class
It is an abstract class that defines the base structure of objects in space required for resolved this problem.

| Properties | Type |
| - | - |
| **Center** | _Vector3D_ |
| **Type** | _Object3DTypes_ |

| Method | Parameters | Scope | Descriction |
| - | - | - | - |
| **CollidesWith**| thatObject | public | Returns if object collides or not with another object |
| **IntersectedVolume** | thatObject  | public | Returns the intersection volume between objects. If objects not collide, then return value zero.|
| **Volume** |   | internal | Return the volume of object.|

## Cube Class
It is a derived class from Object3D and content the implementation for a cube object. In addition to the properties and methods inherited from Object3D, it also has the following defined:

| Properties | Type |
| - | - |
| **Dimensions** | _double_ |
| **XAxis** | _Vector2D_ |

| Method | Parameters | Scope | Descriction |
| - | - | - | - |
| **CollidesWithCube**| thatObject | pprivate | Returns if cube object collides with other cube. |
| **ResolveVolumeIntersectionWithCube** | thatObject  | private | Resolve an returns  the intersection volume when cube object collised with other cube. |

## Coboid Class
It is a derived class from Object3D and content the implementation for a Coboid object. In addition to the properties and methods inherited from Object3D, it also has the following defined:

| Properties | Type |
| - | - |
| **Depth** | _double_ |
| **Height** | _double_ |
| **Width** | _double_ |

## License

MIT
