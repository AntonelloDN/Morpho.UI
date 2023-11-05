![Logo](https://github.com/AntonelloDN/Morpho/blob/master/logo/logo_morpho_32.png)

# Morpho UI
UI to use for CAD plugin

# Examples

```csharp
// JSON string of Grid Entity
var jsonString = "{\"size\":{\"cellDimension\":{\"x\":3,\"y\":3,\"z\":3},\"origin\":{\"x\":0,\"y\":0,\"z\":0},\"numX\":100,\"numY\":100,\"numZ\":25},\"nestingGrids\":{\"firstMaterial\":\"0000XL\",\"secondMaterial\":\"000000\",\"numberOfCells\":3},\"telescope\":0,\"startTelescopeHeight\":0,\"combineGridType\":false}";

// Create grid form
var form = new EntityForm("grid", jsonString);

// Show grid form
form.ShowDialog();
```