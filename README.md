![Logo](https://github.com/AntonelloDN/Morpho/blob/master/logo/logo_morpho_32.png)

# Morpho UI
UI to use for CAD plugin.

### Mapping with Morpho Core
| Morpho entity | Morpho UI constructor | 
| --------------- | --------------- | 
| Grid | `new EntityForm("grid", grid.Serialize())`|
| Building | `new EntityForm("building", grid.Serialize())`|
| Plant2d | `new EntityForm("plant2D", plant2d.Serialize())`|
| Plant3d | `new EntityForm("plant3D", plant3d.Serialize())`|
| Receptor | `new EntityForm("receptor", receptor.Serialize())`|
| Source | `new EntityForm("source", source.Serialize())`|
| Soil | `new EntityForm("soil", soil.Serialize())`|
| Terrain | `new EntityForm("terrain", terrain.Serialize())`|

# Examples
```csharp
// Create grid with Morpho
var nestingGrids = new NestingGrids(3, "000000", "000000");
var size = new Size(new MorphoGeometry.Vector(0, 0, 0), new CellDimension(3, 3, 3), 100, 100, 25);
var eqGrid = new Grid(size, nestingGrids);

// Serialize
var jsonString = eqGrid.Serialize();

// Create grid form
var form = new EntityForm("grid", jsonString);

// Show grid form
form.ShowDialog();

// Get data on submit
var data = form.Connection.Data;

// Deserialize
var newGrid = Grid.Deserialize(data);
```
