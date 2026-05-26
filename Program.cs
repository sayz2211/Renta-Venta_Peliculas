// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hola Bienvenido a nuestra tienda de alquier y ventas de peliculas  ");

// CLIENTES
var clientes = new List<Clientes> {
    new Clientes { Id = 1, Nombre = "Santiago Gómez",  Cedula = "1028140229", Correo = "santiago@gmail.com", Fecha = new DateTime(2024,1,15), Telefono = "3001234567", Id_Status = 1 },
    new Clientes { Id = 2, Nombre = "Camila Vectori",  Cedula = "1000413610", Correo = "camila@gmail.com",   Fecha = new DateTime(2024,2,20), Telefono = "3109876543", Id_Status = 1 },
    new Clientes { Id = 3, Nombre = "Andrés Martínez", Cedula = "1014979387", Correo = "andres@gmail.com",   Fecha = new DateTime(2024,3,10), Telefono = "3152345678", Id_Status = 1 },
    new Clientes { Id = 4, Nombre = "Laura Pérez",     Cedula = "1010155714", Correo = "laura@gmail.com",    Fecha = new DateTime(2024,4,5),  Telefono = "3007654321", Id_Status = 2 },
    new Clientes { Id = 5, Nombre = "Carlos Ríos",     Cedula = "1011395001", Correo = "carlos@gmail.com",   Fecha = new DateTime(2024,5,18), Telefono = "3123456789", Id_Status = 2 },
};
var directores = new List<Directores> {
    new Directores { Id = 1, Nombre = "Anthony Russo",     Nacionalidad = "Estadounidense", Premios = "MTV Movie Award",      CantidadP = 12 },
    new Directores { Id = 2, Nombre = "Christopher Nolan", Nacionalidad = "Británico",      Premios = "Oscar, BAFTA",          CantidadP = 11 },
    new Directores { Id = 3, Nombre = "James Cameron",     Nacionalidad = "Canadiense",     Premios = "Oscar, Globo de Oro",   CantidadP = 8  },
    new Directores { Id = 4, Nombre = "Steven Spielberg",  Nacionalidad = "Estadounidense", Premios = "Oscar, DGA Award",      CantidadP = 35 },
    new Directores { Id = 5, Nombre = "Bong Joon-ho",      Nacionalidad = "Surcoreano",     Premios = "Oscar, Palma de Oro",   CantidadP = 7  },
};


var peliculas = new List<Peliculas> {
    new Peliculas { Id = 1, Nombre = "Avengers: Endgame", Estreno = "2019", Clasi_edad = "PG-13", puntuacion = 9,  Disponibilidad = true,  Id_Director = 1 },
    new Peliculas { Id = 2, Nombre = "Inception",         Estreno = "2009", Clasi_edad = "PG-13", puntuacion = 10, Disponibilidad = true,  Id_Director = 2 },
    new Peliculas { Id = 3, Nombre = "Avatar",            Estreno = "1899", Clasi_edad = "PG-13", puntuacion = 8,  Disponibilidad = false, Id_Director = 3 },
    new Peliculas { Id = 4, Nombre = "Jurassic Park",     Estreno = "1993", Clasi_edad = "PG-13", puntuacion = 9,  Disponibilidad = true,  Id_Director = 4 },
    new Peliculas { Id = 5, Nombre = "Parasite",          Estreno = "2019", Clasi_edad = "R",     puntuacion = 10, Disponibilidad = true,  Id_Director = 5 },
};


var actores = new List<Actores> {
    new Actores { Id = 1, Nombre = "Robert John Downey", Nombre_Artistico = "Robert Downey Jr.", Nacionalidad = "Estadounidense", Premios = "Globo de Oro",       CantidadP = 50 },
    new Actores { Id = 2, Nombre = "Chris Hemsworth",    Nombre_Artistico = "Chris Hemsworth",   Nacionalidad = "Australiano",    Premios = "MTV Movie Award",    CantidadP = 30 },
    new Actores { Id = 3, Nombre = "Leonardo DiCaprio",  Nombre_Artistico = "Leo DiCaprio",      Nacionalidad = "Estadounidense", Premios = "Oscar, Globo de Oro",CantidadP = 40 },
    new Actores { Id = 4, Nombre = "Sam Neill",          Nombre_Artistico = "Sam Neill",         Nacionalidad = "Neozelandés",    Premios = "BAFTA",              CantidadP = 60 },
    new Actores { Id = 5, Nombre = "Song Kang-ho",       Nombre_Artistico = "Song Kang-ho",      Nacionalidad = "Surcoreano",     Premios = "Cannes, Baeksang",   CantidadP = 25 },
};

var repartos = new List<Repartos> {
    new Repartos { Id = 1, Id_Actores = 1, Id_Peliculas = 1, Personaje = "Tony Stark",    Rol = "Principal" },
    new Repartos { Id = 2, Id_Actores = 2, Id_Peliculas = 1, Personaje = "Thor Odinson",  Rol = "Principal" },
    new Repartos { Id = 3, Id_Actores = 3, Id_Peliculas = 2, Personaje = "Dom Cobb",      Rol = "Principal" },
    new Repartos { Id = 4, Id_Actores = 4, Id_Peliculas = 4, Personaje = "Dr. Alan Grant", Rol = "Principal" },
    new Repartos { Id = 5, Id_Actores = 5, Id_Peliculas = 5, Personaje = "Ki-taek",       Rol = "Principal" },
};


var tiposGeneros = new List<TiposGeneros> {
    new TiposGeneros { Id = 1, Genero = "Acción" },
    new TiposGeneros { Id = 2, Genero = "Ciencia Ficción" },
    new TiposGeneros { Id = 3, Genero = "Drama" },
    new TiposGeneros { Id = 4, Genero = "Aventura" },
    new TiposGeneros { Id = 5, Genero = "Thriller" },
};

// 
var status = new List<Status> {
    new Status { Id = 1, status = true  },
    new Status { Id = 2, status = false },
    new Status { Id = 3, status = true  },
    new Status { Id = 4, status = true  },
    new Status { Id = 5, status = false },
};


var sucursales = new List<Sucursales> {
    new Sucursales { Id = 1, Nombre = "CineRenta Centro", Ciudad = "Medellín", Direccion = "Calle 50 #40-20", Telefono = "6044561234" },
    new Sucursales { Id = 2, Nombre = "CineRenta Sur",    Ciudad = "Itagüí",   Direccion = "Cra 52 #10-15",   Telefono = "6044569876" },
    new Sucursales { Id = 3, Nombre = "CineRenta Norte",  Ciudad = "Bello",    Direccion = "Av. 33 #55-10",   Telefono = "6044563456 "},
    new Sucursales { Id = 4, Nombre = "CineRenta Bogotá", Ciudad = "Bogotá",   Direccion = "Calle 72 #11-35", Telefono = "6017891234 "},
    new Sucursales { Id = 5, Nombre = "CineRenta Cali",   Ciudad = "Cali",     Direccion = "Av. 6N #23-10",   Telefono = "6023456789" },
};


var empleados = new List<Empleados> {
    new Empleados { Id = 1, Nombre = "María López",    Ciudad = "Medellín", Correo = "maria@cinerenta.com",     Telefono = "3001112233", Cargo = "Cajero",     Id_Status = 1 },
    new Empleados { Id = 2, Nombre = "Juan Torres",    Ciudad = "Itagüí",   Correo = "juan@cinerenta.com",      Telefono = "3112223344", Cargo = "Supervisor", Id_Status = 1 },
    new Empleados { Id = 3, Nombre = "Paula Vélez",    Ciudad = "Bello",    Correo = "paula@cinerenta.com",     Telefono = "3153334455", Cargo = "Cajero",     Id_Status = 1 },
    new Empleados { Id = 4, Nombre = "Diego Mora",     Ciudad = "Bogotá",   Correo = "diego@cinerenta.com",     Telefono = "3004445566", Cargo = "Gerente",    Id_Status = 2 },
    new Empleados { Id = 5, Nombre = "Valentina Cruz", Ciudad = "Cali",     Correo = "valentina@cinerenta.com", Telefono = "3125556677", Cargo = "Asesor",     Id_Status = 1 },
};

var proveedores = new List<Proveedores> {
    new Proveedores { Id = 1, Nombre = "Distribuidora Warner", Telefono = "6014561234", Correo = "warner@dist.com",    Ciudad = "Bogotá"      },
    new Proveedores { Id = 2, Nombre = "Sony Pictures Dist.",  Telefono = "6024569876", Correo = "sony@dist.com",      Ciudad = "Cali"        },
    new Proveedores { Id = 3, Nombre = "Universal Films CO",   Telefono = "6044563456", Correo = "universal@dist.com", Ciudad = "Medellín"    },
    new Proveedores { Id = 4, Nombre = "Paramount Dist. SAS",  Telefono = "6057891234", Correo = "paramount@dist.com", Ciudad = "Barranquilla"},
    new Proveedores { Id = 5, Nombre = "Disney Latam Dist.",   Telefono = "6044567890", Correo = "disney@dist.com",    Ciudad = "Medellín"    },
};


var formatos = new List<Formatos> {
    new Formatos { Id = 1, Formato = "DVD",     Idioma = "Español", Subtitulada = false, Disponible = true  },
    new Formatos { Id = 2, Formato = "Blu-ray", Idioma = "Inglés",  Subtitulada = true,  Disponible = true  },
    new Formatos { Id = 3, Formato = "4K UHD",  Idioma = "Inglés",  Subtitulada = true,  Disponible = true  },
    new Formatos { Id = 4, Formato = "DVD",     Idioma = "Inglés",  Subtitulada = true,  Disponible = false },
    new Formatos { Id = 5, Formato = "Blu-ray", Idioma = "Español", Subtitulada = false, Disponible = true  },
};


var inventarios = new List<Inventarios> {
    new Inventarios { Id = 1, Id_Peliculas = 1, Cantidad = 10, Id_Formatos = 1, Id_Sucursal = 1, Id_Proveedor = 1 },
    new Inventarios { Id = 2, Id_Peliculas = 2, Cantidad = 5,  Id_Formatos = 2, Id_Sucursal = 2, Id_Proveedor = 3 },
    new Inventarios { Id = 3, Id_Peliculas = 3, Cantidad = 8,  Id_Formatos = 3, Id_Sucursal = 1, Id_Proveedor = 5 },
    new Inventarios { Id = 4, Id_Peliculas = 4, Cantidad = 3,  Id_Formatos = 1, Id_Sucursal = 3, Id_Proveedor = 2 },
    new Inventarios { Id = 5, Id_Peliculas = 5, Cantidad = 7,  Id_Formatos = 2, Id_Sucursal = 4, Id_Proveedor = 4 },
};


var formatosPeliculas = new List<Formatos_Peliculas> {
new Formatos_Peliculas { Id = 1, Id_Peliculas = 1, Id_Fomatos = 1, Id_Invetarios = 1, Precio_Formato = 12000m },
new Formatos_Peliculas { Id = 2, Id_Peliculas = 2, Id_Fomatos = 2, Id_Invetarios = 2, Precio_Formato = 18000m },
new Formatos_Peliculas { Id = 3, Id_Peliculas = 3, Id_Fomatos = 3, Id_Invetarios = 3, Precio_Formato = 25000m },
new Formatos_Peliculas { Id = 4, Id_Peliculas = 4, Id_Fomatos = 1, Id_Invetarios = 4, Precio_Formato = 10000m },
new Formatos_Peliculas { Id = 5, Id_Peliculas = 5, Id_Fomatos = 2, Id_Invetarios = 5, Precio_Formato = 20000m },
};


var rentas = new List<Rentas> {
    new Rentas { Id = 1, Precio_Dia = 5000m,  Cantidad = 1, Fecha_Renta = new DateTime(2024,6,1),  Fecha_Limite = new DateTime(2024,6,5)  },
    new Rentas { Id = 2, Precio_Dia  = 8000m,  Cantidad = 2, Fecha_Renta = new DateTime(2024,6,10), Fecha_Limite = new DateTime(2024,6,14) },
    new Rentas { Id = 3, Precio_Dia  = 5000m,  Cantidad = 1, Fecha_Renta = new DateTime(2024,7,1),  Fecha_Limite = new DateTime(2024,7,4)  },
    new Rentas { Id = 4, Precio_Dia  = 10000m, Cantidad = 3, Fecha_Renta = new DateTime(2024,7,15), Fecha_Limite = new DateTime(2024,7,19) },
    new Rentas { Id = 5, Precio_Dia  = 5000m,  Cantidad = 1, Fecha_Renta = new DateTime(2024,8,1),  Fecha_Limite = new DateTime(2024,8,5)  },
};


var rentasPeliculas = new List<Rentas_Peliculas> {
new Rentas_Peliculas { Id = 1, Id_Rentas = 1, Id_Peliculas = 1, Id_Formatos_Peliculas = 1, Cantidad = 1, Dias = 4, Precio_Dia = 5000m,  Subtotal = 20000m },
new Rentas_Peliculas { Id = 2, Id_Rentas = 2, Id_Peliculas = 2, Id_Formatos_Peliculas = 2, Cantidad = 2, Dias = 4, Precio_Dia = 8000m,  Subtotal = 32000m },
new Rentas_Peliculas { Id = 3, Id_Rentas = 3, Id_Peliculas = 3, Id_Formatos_Peliculas = 3, Cantidad = 1, Dias = 3, Precio_Dia = 5000m,  Subtotal = 15000m },
new Rentas_Peliculas { Id = 4, Id_Rentas = 4, Id_Peliculas = 4, Id_Formatos_Peliculas = 4, Cantidad = 3, Dias = 4, Precio_Dia = 10000m, Subtotal = 40000m },
new Rentas_Peliculas { Id = 5, Id_Rentas = 5, Id_Peliculas = 5, Id_Formatos_Peliculas = 5, Cantidad = 1, Dias = 4, Precio_Dia = 5000m,  Subtotal = 20000m },
};


var ventas = new List<Ventas> {
    new Ventas { Id = 1, Precio_Venta = 25000m, Cantidad = 1 },
    new Ventas { Id = 2, Precio_Venta = 50000m, Cantidad = 2 },
    new Ventas { Id = 3, Precio_Venta = 35000m, Cantidad = 1 },
    new Ventas { Id = 4, Precio_Venta = 75000m, Cantidad = 3 },
    new Ventas { Id = 5, Precio_Venta = 25000m, Cantidad = 1 },
};


var ventasPeliculas = new List<Ventas_Peliculas> {
    new Ventas_Peliculas { Id = 1, Id_Ventas = 1, Id_Peliculas = 1, Id_Formatos_Peliculas = 1, Cantidad = 1, Precio_U = 25000m, Subtotal = 25000m },
    new Ventas_Peliculas { Id = 2, Id_Ventas = 2, Id_Peliculas = 2, Id_Formatos_Peliculas = 2, Cantidad = 2, Precio_U = 25000m, Subtotal = 50000m },
    new Ventas_Peliculas { Id = 3, Id_Ventas = 3, Id_Peliculas = 3, Id_Formatos_Peliculas = 3, Cantidad = 1, Precio_U = 35000m, Subtotal = 35000m },
    new Ventas_Peliculas { Id = 4, Id_Ventas = 4, Id_Peliculas = 4, Id_Formatos_Peliculas = 4, Cantidad = 3, Precio_U = 25000m, Subtotal = 75000m },
    new Ventas_Peliculas { Id = 5, Id_Ventas = 5, Id_Peliculas = 5, Id_Formatos_Peliculas = 5, Cantidad = 1, Precio_U = 25000m, Subtotal = 25000m },
};


var facturas = new List<Facturas> {
    new Facturas { Id = 1, Codigo = "1001", Fecha = new DateTime(2024,6,1),  Id_Clientes = 1, Id_Rentas = 1, Id_Ventas = 0, Id_Descuentos = 0, Total = 20000m  },
    new Facturas { Id = 2, Codigo = "1002", Fecha = new DateTime(2024,6,10), Id_Clientes = 2, Id_Rentas = 0, Id_Ventas = 1, Id_Descuentos = 0, Total = 25000m  },
    new Facturas { Id = 3, Codigo = "1003", Fecha = new DateTime(2024,7,1),  Id_Clientes = 3, Id_Rentas = 3, Id_Ventas = 0, Id_Descuentos = 1, Total = 13500m  },
    new Facturas { Id = 4, Codigo = "1004", Fecha = new DateTime(2024,7,15), Id_Clientes = 4, Id_Rentas = 4, Id_Ventas = 2, Id_Descuentos = 0, Total = 115000m },
    new Facturas { Id = 5, Codigo = "1005", Fecha = new DateTime(2024,8,1),  Id_Clientes = 5, Id_Rentas = 5, Id_Ventas = 0, Id_Descuentos = 0, Total = 20000m  },
};


var devoluciones = new List<Devoluciones> {
    new Devoluciones { Id = 1, Id_Clientes = 1, Fecha = new DateTime(2024,6,6),  Id_Peliculas = 1, Id_Facturas = 1, Multa = "Entrega tardía",  Precio_Multa = 5000m  },
    new Devoluciones { Id = 2, Id_Clientes = 3, Fecha = new DateTime(2024,7,5),  Id_Peliculas = 3, Id_Facturas = 3, Multa = "Sin multa",        Precio_Multa = 0m     },
    new Devoluciones { Id = 3, Id_Clientes = 2, Fecha = new DateTime(2024,6,15), Id_Peliculas = 2, Id_Facturas = 2, Multa = "Disco rayado",     Precio_Multa = 15000m },
    new Devoluciones { Id = 4, Id_Clientes = 4, Fecha = new DateTime(2024,7,20), Id_Peliculas = 4, Id_Facturas = 4, Multa = "Entrega tardía",   Precio_Multa = 5000m  },
    new Devoluciones { Id = 5, Id_Clientes = 5, Fecha = new DateTime(2024,8,6),  Id_Peliculas = 5, Id_Facturas = 5, Multa = "Sin multa",        Precio_Multa = 0m     },
};


var reclamos = new List<Reclamos> {
    new Reclamos { Id = 1, Id_Facturas = 3, Motivo = "Disco en mal estado",       Fecha = new DateTime(2024,7,2),  Garantia = "Cambio de disco"    },
    new Reclamos { Id = 2, Id_Facturas = 1, Motivo = "Precio cobrado incorrecto", Fecha = new DateTime(2024,6,2),  Garantia = "Devolución dinero"  },
    new Reclamos { Id = 3, Id_Facturas = 4, Motivo = "Pelicula equivocada",       Fecha = new DateTime(2024,7,16), Garantia = "Cambio de película" },
    new Reclamos { Id = 4, Id_Facturas = 2, Motivo = "Caja dañada",               Fecha = new DateTime(2024,6,11), Garantia = "Sin garantía"       },
    new Reclamos { Id = 5, Id_Facturas = 5, Motivo = "No reproduce en equipo",    Fecha = new DateTime(2024,8,2),  Garantia = "Cambio de disco"    },
};

var descuentos = new List<Descuentos> {
    new Descuentos { Id = 1, Descripcion = "Descuento estudiante",  Porcentaje = 10m, Activo = true  },
    new Descuentos { Id = 2, Descripcion = "Descuento adulto mayor", Porcentaje = 15m, Activo = true  },
    new Descuentos { Id = 3, Descripcion = "Descuento temporada",   Porcentaje = 20m, Activo = true  },
    new Descuentos { Id = 4, Descripcion = "Descuento empleado",    Porcentaje = 25m, Activo = true  },
    new Descuentos { Id = 5, Descripcion = "Descuento fidelidad",   Porcentaje = 5m,  Activo = false },
};

public class Clientes {
public int Id  { get; set; }
public string ? Nombre  { get; set; } 
public string ? Cedula   { get; set; } 
public String ? Correo  { get; set; }  
public DateTime Fecha   { get; set; } 
public string? Telefono   { get; set; } 
public int Id_Status { get; set; }        
 public Status? Status { get; set; } 
public List<Facturas>? Facturas { get; set; }
public List<Devoluciones>? Devoluciones { get; set; }
};


public class Peliculas {
public int Id  { get; set; }
public string? Nombre  { get; set; } 
public string ?  Estreno { get; set; } 
public string? Clasi_edad { get; set; } 
public int puntuacion  { get; set; } 
public bool Disponibilidad  { get; set; } 
public int Id_Director { get; set; }
public Directores? Director { get; set; } 
public List < TiposGeneros>? TiposGeneros { get; set; }
public List<Repartos>? Repartos { get; set; }
 public List<Formatos_Peliculas>? Formatos_Peliculas { get; set; }
public List<Inventarios>? Inventarios { get; set; }
 public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
 public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }

};

public class TiposGeneros
{
    public int Id  { get; set; }

    public string ? Genero { get; set; }
     public Peliculas? Pelicula { get; set; }

}

public class Status 
{
    public int Id  { get; set; }
    public bool status  { get; set; }
     public List<Clientes>? Clientes { get; set; }
    public List<Empleados>? Empleados { get; set; }
}


public class Facturas
{
 public int Id  { get; set; }
public  string? Codigo  { get; set; } 
public DateTime Fecha   { get; set; } 
 public int Id_Clientes  { get; set; }
 public int Id_Rentas { get; set; }
 public int Id_Ventas { get; set; }
 public int Id_Descuentos { get; set; }
 public decimal Total { get; set; } = 0.0m ;
 public Clientes? Cliente { get; set; }
 public Rentas? Renta { get; set; }
  public Ventas? Venta { get; set; }
public List<Reclamos>? Reclamos { get; set; }
public List<Devoluciones>? Devoluciones { get; set; }

}

public class Rentas 
{
public int Id  { get; set; }
public decimal Precio_Dia { get; set; } = 0.0m ;
public  int Cantidad { get; set; } 
public DateTime Fecha_Renta  { get; set; } 
public DateTime Fecha_Limite { get; set; } 
 public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
 public List<Facturas>? Facturas { get; set; }
}


public class Ventas {
public int Id  { get; set; }
public decimal Precio_Venta { get; set; } = 0.0m ;
public  int Cantidad { get; set; } 

public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
public List<Facturas>? Facturas { get; set; }

}

public class Actores {
public int Id  { get; set; }
public string? Nombre { get; set; }
public string? Nombre_Artistico { get; set; }
public string? Nacionalidad { get; set; }
public string? Premios { get; set; }
public  int CantidadP { get; set; } 

public List<Repartos>? Repartos { get; set; }

}


public class Directores {
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Nacionalidad { get; set; }
    public string? Premios { get; set; }
    public int CantidadP { get; set; }
    public List<Peliculas>? Peliculas { get; set; } 
}



public class Repartos {
public int Id  { get; set; }
public int Id_Actores  { get; set; }
public int Id_Peliculas  { get; set; }
public string? Personaje { get; set; }
public string? Rol { get; set; }

public Actores? Actor { get; set; }
public Peliculas? Pelicula { get; set; }

}

public class Sucursales  {
    
public int Id  { get; set; }
public string? Nombre { get; set; }
public string? Ciudad { get; set; }
public string? Direccion { get; set; }
public string? Telefono { get; set; }
public List<Empleados>? Empleados { get; set; }
public List<Inventarios>? Inventarios { get; set; }

}

public class Empleados  {
    
public int Id  { get; set; }
public string? Nombre { get; set; }
public string? Ciudad { get; set; }
public string? Correo { get; set; }
public string? Telefono { get; set; }
public string? Cargo { get; set; }
public int Id_Status { get; set; }        
public Status? Status { get; set; }
public Sucursales? Sucursal { get; set; }

}

public class Formatos   {
    
public int Id  { get; set; }
public string? Formato { get; set; }
public string? Idioma { get; set; }
public bool Subtitulada { get; set; }
public bool Disponible  { get; set; }
 public List<Formatos_Peliculas>? Formatos_Peliculas { get; set; }

}


public class Formatos_Peliculas   {
    
public int Id  { get; set; }
public int Id_Peliculas{ get; set; }
public int Id_Fomatos { get; set; }
public int Id_Invetarios{ get; set; }
public decimal Precio_Formato{ get; set; } = 0.0m ;
public Peliculas? Pelicula { get; set; }
 public Formatos? Formato { get; set; }
 public Inventarios? Inventario { get; set; }
 public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
 public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }

}



public class Inventarios   {
    
public int Id  { get; set; }

public int Id_Peliculas{ get; set; }
public int Cantidad { get; set; }
public int Id_Formatos { get; set; }
public int Id_Sucursal { get; set; }
public Peliculas? Pelicula { get; set; }
public Formatos? Formato { get; set; }
public Sucursales? Sucursal { get; set; }
public int Id_Proveedor { get; set; }
public Proveedores? Proveedor { get; set; }

}

public class Proveedores {
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Ciudad { get; set; }
    public List<Inventarios>? Inventarios { get; set; } 
}



public class Ventas_Peliculas   {
    
public int Id  { get; set; }
public int Id_Ventas { get; set; }
public int Id_Peliculas{ get; set; }
public int Id_Formatos_Peliculas { get; set; }
public decimal Precio_U { get; set; } = 0.0m ;
public int Cantidad { get; set; }
 public decimal Subtotal { get; set; }
public Ventas? Venta { get; set; }
public Peliculas? Pelicula { get; set; }
public Formatos_Peliculas? Formato_Pelicula { get; set; }
}

public class Rentas_Peliculas   {
    
public int Id  { get; set; }
public int Id_Rentas { get; set; }
public int Id_Peliculas{ get; set; }
public int Id_Formatos_Peliculas { get; set; }
public int Cantidad { get; set; }
public int Dias { get; set; }
  public decimal Precio_Dia { get; set; }
public decimal Subtotal { get; set; } = 0.0m ;
public Rentas? Renta { get; set; }
public Peliculas? Pelicula { get; set; }
public Formatos_Peliculas? Formato_Pelicula { get; set; } 

}

public class Devoluciones  {
    
public int Id  { get; set; }
public int Id_Clientes  { get; set; }
public DateTime Fecha { get; set; } 
public int Id_Peliculas{ get; set; }
public int Id_Facturas { get; set; }
public string? Multa { get; set; }
public decimal Precio_Multa { get; set; } = 0.0m ;
 public Clientes? Cliente { get; set; }
 public Peliculas? Pelicula { get; set; }
 public Facturas? Factura { get; set; }

}


public class  Reclamos {
    
public int Id  { get; set; }
public int Id_Facturas { get; set; }
public string? Motivo { get; set; }
public DateTime Fecha { get; set; } 
public string? Garantia { get; set; }
public Facturas? Factura { get; set; }

}

public class Descuentos {
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public decimal Porcentaje { get; set; }
    public bool Activo { get; set; }
    public List<Facturas>? Facturas { get; set; }
}