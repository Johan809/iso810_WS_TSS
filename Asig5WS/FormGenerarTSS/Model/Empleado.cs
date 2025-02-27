namespace FormGenerarTSS.Model
{
    public class Empleado
    {
        public string TipoRegistro { get; set; } = "D";
        public string Nss { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal SueldoMensual { get; set; }
        public decimal MontoCotizable { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoContrato { get; set; }
        public string Estado { get; set; }

        private static readonly List<string> NssValues = new()
        {
            "001234567890", "001234567891", "001234567892", "001234567893", "001234567894",
            "001234567895", "001234567896", "001234567897", "001234567898", "001234567899",
            "001234567900", "001234567901", "001234567902", "001234567903", "001234567904"
        };

        private static readonly List<string> CedulaValues = new()
        {
            "123456789", "987654321", "456789123", "789123456", "321654987",
            "654987321", "321456987", "147258369", "258369147", "369147258",
            "111222333", "444555666", "777888999", "333444555", "888777666"
        };

        private static readonly List<string> NombresValues = new()
        {
            "Juan", "María", "Pedro", "Ana", "Luis", "Sofía", "Carlos", "Elena", "Miguel", "Laura",
            "José", "Lucía", "Andrés", "Clara", "Pablo"
        };

        private static readonly List<string> ApellidosValues = new()
        {
            "Pérez", "González", "Martínez", "López", "Rodríguez", "Fernández", "Morales", "Santos",
            "Jiménez", "Torres", "Ramírez", "Castillo", "Díaz", "Cruz", "Herrera"
        };

        public static Empleado[] GetEmpleados(int cantidad = 10)
        {
            Random random = new();
            Empleado[] empleados = new Empleado[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                empleados[i] = new Empleado
                {
                    Nss = NssValues[random.Next(NssValues.Count)],
                    Cedula = CedulaValues[random.Next(CedulaValues.Count)],
                    Nombres = NombresValues[random.Next(NombresValues.Count)],
                    Apellidos = ApellidosValues[random.Next(ApellidosValues.Count)],
                    SueldoMensual = random.Next(35000, 60001), // Sueldo entre 35,000 y 60,000
                    MontoCotizable = random.Next(32000, 58001), // Salario cotizable entre 32,000 y 58,000
                    FechaIngreso = DateTime.Today.AddDays(-random.Next(500, 3000)), // Fecha entre 500 y 3000 días atrás
                    TipoContrato = random.Next(0, 2) == 0 ? "P" : "T",
                    Estado = random.Next(0, 2) == 0 ? "A" : "S"
                };
            }

            return empleados;
        }
    }
}
