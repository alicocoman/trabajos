// ejercicio 1

@model Obligatorio2Programacion2.Models.Usuario

@{
    ViewBag.Title = "Registrarse";
}

<h2>Registrarse</h2>


@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()

    <div class="form-horizontal">
        <h4>Usuario</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.Nombre, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Nombre, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Nombre, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Apellido, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Apellido, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Apellido, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Cedula, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Cedula, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Cedula, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Password, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Password, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" required />
            </div>
        </div>
    </div>
}

//ejercicio 2

        // POST: Usuario/Registrarse
        [HttpPost]
        public ActionResult Registrarse(Usuario u)
        {
		if( (string) Session["logueadoUsuario"] != null){

          
                Usuario Usu =  a.agregarCliente(u.Nombre, u.Apellido, u.Cedula, u.Password);
                a.agregarCliente(u.Nombre, u.Apellido, u.Cedula, u.Password);
                if (Usu != null)
                {
                    

                    ViewBag.Msg = "Bienvenido " + Usu.Nombre + " " + Usu.Apellido + " Inicie sesion para continuar";

                }
                else {
                    ViewBag.Msg = "No se pudo Registrar su usuario, verifique sus datos";
                }
                
                return View("../Home/Index");
                
            }
            else
            {
                return View();
            }
        }
		


//ejercicio 3
//En Vista Home/LogIn
@model ActuacionEnClase.Models.LogInModel

@{
    ViewBag.Title = "LogIn";
}

<h2>LogIn</h2>


@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>LogInModel</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.Usuario, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Usuario, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Usuario, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Password, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Password, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Ingresar" class="btn btn-default" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Volver a la pagina principal", "Index")
</div>

//En HomeController

    public ActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel L )
        {
            foreach (Usuario u in a.GetUsuarios())
            {
                if (u.NombreUsu == L.Usuario && u.Password == L.Password) {
                    Session["logueadoRol"] =u.Rol;

                    if (u.Rol == "Cliente") {
                        Session["logueadoNombre"] = u.Nombre;
                        Session["logueadoApellido"] = u.Apellido;
                        Session["logueadoUsuario"] = u.NombreUsu;
                    }
                }
            }
			if((string)  Session["logueadoNombre"] !=null){
				ViewBag.Msg="Bienvenid@" + Session["logueadoNombre"];
				
			}
			else{
				ViewBag.Msg="Nombre de usuario o contraseña incorrectos Verifique sus datos";
			}

            return RedirectToAction("Index");
        }
		

//Ejercicio 4 
//Vista Ticket Index

@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()
    
<div class="form-horizontal">
  
    <h3>Numero de ticket</h3>

    @ViewBag.Ticket.Id

    <h3>Usuarios</h3>

    @foreach (var Usuario in ViewBag.Ticket.GetUsuarios())
    {
        <h4>Nombre</h4>
        <p>@Usuario.Nombre</p>
        <h4>Apellido</h4>
        <p>@Usuario.Apellido</p>
        <h4>Cedula</h4>
        <p>@Usuario.Cedula</p>
        
        <p>------------------------------------------------</p>


    }


//Ejercicio 5
  public class Usuario: IComparable<Usuario>
    {
             
       public int CompareTo(Usuario other)
       {
          if (this.Apellido.CompareTo(other.Apellido) > 0) {
              return 1;
            }
            else if (this.Apellido.CompareTo(other.Apellido) < 0) {
               return -1;
            }
           else {
                  return 0;
                }
            }
        }

    }

//No funciona la venta de articulo. ¿Qué sucede?
//No funciona ya que el actionResult esta mal "targeteado" ya que tendria que ser Venta con Mayuscula en el GET VENTA
// y los id tendrian que ser iguales entre la vista y el controller

//tendria que pasar un if por razor dependiendo del modelo , ya que llega nulo y se anula la vista



Indique verdadero o falso
1 – Es posible guardar datos en los controladores y acceder a ellos más tarde.
	Falso
	
2 – El IIS permite manejar el tiempo de sesión de una aplicación.
	Verdadero
3 – Las vistas deben tener un método action result en su controller.
	Verdadero
4 – La vista Index de artículo, requiere un método action result de nombre
“index” en el ArticuloController.
Falso Requiere un metodo action result llamado "Index"
