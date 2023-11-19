using Morpho.Envimet.UI;
using Morpho25.Geometry;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        while (true)
        {

            var components = new Dictionary<string, string>()
        {
            {  "1", "GridForm" },
            {  "2", "BuildingForm" },
            {  "3", "Plant2DForm" },
            {  "4", "Plant3DForm" },
            {  "5", "Receptor" },
            {  "6", "Soil" },
            {  "7", "Source" },
            {  "8", "Terrain" },
            {  "9", "Location" },
        };

            var componentsTxt = String.Join("\n", components.Select(_ => $"{_.Value} - {_.Key}"));

            Console.WriteLine(componentsTxt);
            var component = Console.ReadLine();


            if (component == null) return;

            if (component == "1")
            {
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
                Console.Write(newGrid.ToString());
            }

            if (component == "2")
            {
                // Deserialize
                var jsonString = "{\"observeBPS\":false,\"geometry\":{\"faces\":[{\"vertices\":[{\"x\":0.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]},{\"vertices\":[{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":5.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]}]},\"material\":{\"ids\":[\"000000\",\"000000\",\" \",\" \"]},\"name\":\"Building\",\"id\":1}";

                EntityForm browser = new EntityForm("building", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }

            if (component == "3")
            {
                // Deserialize
                var jsonString = "{\"geometry\":{\"faces\":[{\"vertices\":[{\"x\":0.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]},{\"vertices\":[{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":5.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]}]},\"name\":\"PlantGroup\",\"material\":{\"ids\":[\"0000XX\"]},\"id\":1}";

                EntityForm browser = new EntityForm("plant2D", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }

            if (component == "4")
            {
                // Deserialize
                var jsonString = "{\"name\":\"PlantGroup\",\"geometry\":{\"x\":10.0,\"y\":10.0,\"z\":0.0},\"material\":{\"ids\":[\"0000C2\"]},\"id\":0}";

                EntityForm browser = new EntityForm("plant3D", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }

            if (component == "5")
            {
                // Deserialize
                var jsonString = "{\"name\":\"MyReceptor\",\"geometry\":{\"x\":10.0,\"y\":10.0,\"z\":0.0},\"id\":0}";

                EntityForm browser = new EntityForm("receptor", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }

            if (component == "6")
            {
                // Deserialize
                var jsonString = "{\"name\":\"SoilGroup\",\"geometry\":{\"faces\":[{\"vertices\":[{\"x\":0.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]},{\"vertices\":[{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":5.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]}]},\"material\":{\"ids\":[\"000000\"]},\"id\":1}";

                EntityForm browser = new EntityForm("soil", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }

            if (component == "7")
            {
                // Deserialize
                var jsonString = "{\"name\":\"SourceGroup\",\"geometry\":{\"faces\":[{\"vertices\":[{\"x\":0.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]},{\"vertices\":[{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":5.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]}]},\"material\":{\"ids\":[\"0000FT\"]},\"id\":1}";

                EntityForm browser = new EntityForm("source", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }

            if (component == "8")
            {
                // Deserialize
                var jsonString = "{\"name\":\"TerrainGroup\",\"geometry\":{\"faces\":[{\"vertices\":[{\"x\":0.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]},{\"vertices\":[{\"x\":5.0,\"y\":0.0,\"z\":0.0},{\"x\":5.0,\"y\":5.0,\"z\":0.0},{\"x\":0.0,\"y\":5.0,\"z\":0.0}]}]},\"id\":1}";

                EntityForm browser = new EntityForm("terrain", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }

            if (component == "9")
            {
                // Deserialize
                var jsonString = "{\"locationName\":\"Envimet Location\",\"latitude\":42.0,\"longitude\":12.0,\"timezoneReference\":15.0,\"timeZone\":\"GMT\",\"modelRotation\":0.0}";

                EntityForm browser = new EntityForm("location", jsonString);
                browser.ShowDialog();

                // Serialize
                Console.WriteLine(browser.Connection.Data);
            }
        }
    }
}
