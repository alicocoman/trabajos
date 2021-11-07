$(document).ready(inicio);


// Variables y Arrays //
let colaboradores = [];
let logeado = null;
let admin = new Administrador("Joaquin", "Rodriguez", "chef", "chef-01");
let recetas = [];
let ultimoIdReceta = 1;
let ultimoIdColaborador = 1;
let ordenPorTiempo = [];
let busquedas = [];
let busquedasConBotonesAprobacion = 0;
let busquedasVieja = [];

// INICIO PRECARGA Y CLICKS//
function inicio() {
     precargaDeDatos();
     eventosDeClick();
     interfazUsuarioFinal();

}

//Precarga de datos
function precargaDeDatos() {
     let c0 = altaColaborador("Matias", "Lucero", "mlucero", "m-lucero", ultimoIdColaborador, true);
     let c1 = altaColaborador("Nicolas", "Aguirre", "naguirre", "n-aguirre", ultimoIdColaborador, true);
     let c2 = altaColaborador("Yanina", "Mansilla", "ymansilla", "y-mansilla", ultimoIdColaborador, false);
     let c3 = altaColaborador("Nahuel", "Pereira", "npereira", "n-pereira", ultimoIdColaborador, false);
     let c4 = altaColaborador("Christian", "Alico", "calico", "c-alico", ultimoIdColaborador, true);
     let r0 = altaReceta(ultimoIdReceta, c1.nombre + " " + c1.apellido, "Crema de calabaza", "60", "Cortar la calabaza en trozos y salpimentar.Hornear la calabaza a 180º C hasta que esté blanda.Caramelizar las cebollas a fuego lento con la mantequilla.", 20, 30, "Cremadecalabaza.jpg", "naguirre");
     let r1 = altaReceta(ultimoIdReceta, admin.nombre + " " + admin.apellido, "Salmón al horno", "50", "Engrasar un fuente de horno y colocar el salmón con la piel hacia abajo.Salpimentar y añadir el eneldo y la ralladura del limón.Hornear a 180º C.", 10, 5, "Salmonalhorno.jpg", "chef");
     let r2 = altaReceta(ultimoIdReceta, c2.nombre + " " + c2.apellido, "Tartaletas de manzana", "40", "Cortar las manzanas peladas en láminas finas.Estirar el hojaldre, pintar con mantequilla y espolvorear azúcar moreno.Colocar la manzana.", 15, 5, "tartaletasdemanzana.jpg", "ymansilla");
     let r3 = altaReceta(ultimoIdReceta, c1.nombre + " " + c1.apellido, "Tostada de queso brie", "45", "Partir la cebolla en tiras finasPoner la mantequilla en una sartén y cuando esté derretida añadir la cebolla. Cocinar a fuego muy lento.", 0, 0, "Tostadadequesobrie.jpg", "naguirre");
     let r4 = altaReceta(ultimoIdReceta, c2.nombre + " " + c2.apellido, "Coliflor al horno", "35", "Cocer la coliflor durante 10 minutos. Meter en una picadora la coliflor cocida y la cebolleta. Añadir el huevo, el pan rallado y el queso.", 5, 0, "Colifloralhorno.jpg", "ymansilla");
     let r5 = altaReceta(ultimoIdReceta, admin.nombre + " " + admin.apellido, "Rollitos de pollo con queso", "90", "Amasar los filetes con un rodillo hasta conseguir un grosor uniforme.Untar el queso azul, echar las nueces picadas y enrollar el filete.", 80, 50, "Rollitosdepolloconqueso.jpg", "chef");
     let r6 = altaReceta(ultimoIdReceta, c0.nombre + " " + c0.apellido, "Mousse de café", "30", "Calentar el café instantáneo y la leche condensada en una olla a fuego lento por 5 minutos.Enfriar en la nevera la mezcla durante 30 minutos.", 15, 5, "Moussedecafe.jpg", "mlucero");
     let r7 = altaReceta(ultimoIdReceta, c1.nombre + " " + c1.apellido, "Pasta con camarones al ajo", "80", "Cocer los espaguetis al dente.Rehogar el ajo y el chile junto al perejil.Añadir a la sarten los camarones.Escurrir el espagueti. ", 50, 20, "Pastaconcamaronesalajo.jpg", "naguirre");
     let r8 = altaReceta(ultimoIdReceta, admin.nombre + " " + admin.apellido, "Lasaña de patata", "67", "Cortar las patatas en finas capas y colocarlas en la base de un molde para hornear.Verter 100 gr. de salsa boloñesa y colocar en capas la espinaca y el queso. ", 37, 70, "lasaniadepatata.jpg", "chef");
     let r9 = altaReceta(ultimoIdReceta, c4.nombre + " " + c4.apellido, "Hojaldres de queso y setas", "86", "Cocinar los champiñones en una sartén con un diente de ajo picado.Estirar la masa de hojaldre y colocar los ingredientes en el centro.", 60, 22, "Hojaldresdequesoysetas.jpg", "calico");
     let r10 = altaReceta(ultimoIdReceta, c0.nombre + " " + c0.apellido, "Ensalada con pasta y salmón", "140", "Hierve la pasta según las instrucciones del fabricante. Corta el salmón a trozos pequeños. Trocea los tomates cherry y pica el cebollino. Mezcla.", 60, 80, "ensaladapasta.jpg", "mlucero");
     let r11 = altaReceta(ultimoIdReceta, c2.nombre + " " + c2.apellido, "Salmorejo con jamón y huevo duro", "48", "Pela los tomates. Tritura junto con el ajo hasta obtener una textura sin grumos. Añade el pan, la sal y el aceite y tritura de nuevo.", 0, 0, "salmorejo.jpg", "ymansilla");
     let r12 = altaReceta(ultimoIdReceta, c3.nombre + " " + c3.apellido, "Brócoli con arroz basmati, gambas y cebolla", "73", "Cuece por un lado el arroz basmati y por otro el brócoli previamente lavado y troceado. En una sartén, dora la cebolla cortada a láminas.", 43, 10, "brocoli.jpg", "npereira");
     let r13 = altaReceta(ultimoIdReceta, admin.nombre + " " + admin.apellido, "Brocheta de pechuga de pavo con verduras", "89", "Trocea el pollo y salpimiéntalo. Limpia y trocea las verduras a cubos pequeños. Monta los ingredientes en la brocheta y cocínalos.", 23, 42, "brocheta.jpg", "chef");
     let r14 = altaReceta(ultimoIdReceta, c3.nombre + " " + c3.apellido, "Tiras de pollo rebozado con sésamo y ensalada de espinacas, tomate y queso fresco", "23", "Corta las pechugas de pollo a tiras más bien gruesas. Bate un huevo. Reboza las tiras primero en el huevo, luego en el pan rayado.", 58, 16, "tirasdepollo.jpg", "npereira");
     let r15 = altaReceta(ultimoIdReceta, c0.nombre + " " + c0.apellido, "Ensalada de cuscús, garbanzos y naranja", "13", "Cuece el cuscús según las instrucciones del fabricante. Escurre y lava bien los garbanzos. Pela la naranja y trocéala en cubos pequeños.", 45, 12, "ensaladacuscus.jpg", "mlucero");
     let r16 = altaReceta(ultimoIdReceta, c1.nombre + " " + c1.apellido, "Tortilla de setas shiitake y espárragos trigueros", "48", "Lava y trocea las setas y los espárragos y trocéalos. En una sartén con una cucharada de aceite de oliva, haz una tortilla. A continuación fríe los ingredientes.", 8, 62, "tortilla.jpg", "naguirre");
     let r17 = altaReceta(ultimoIdReceta, c4.nombre + " " + c4.apellido, "Ensalada de judía verde, huevo duro y atún", "29", "Limpia y trocea las judías. Cuécelas durante 10 minutos en agua hirviendo. Mientras, cuece también el huevo. Escurre las judías y déjalas enfriar.", 38, 38, "ensaladajudia.jpg", "calico");
     let r18 = altaReceta(ultimoIdReceta, c2.nombre + " " + c2.apellido, "Pasteles de calabacín", "149", "Tan sencillo como cortar el calabacín en finas rodajas, batir el resto de ingredientes, incorporar la verdura, rellenar los moldes y hornear.", 42, 34, "pasteles.jpg", "ymansilla");
     let r19 = altaReceta(ultimoIdReceta, c3.nombre + " " + c3.apellido, "Longanizas con col y zanahoria", "103", "Las salchichas y la col son dos ingredientes muy empleados en la cocina alemana. Ambos vamos a utilizarlos en esta receta.", 22, 53, "longaniza.jpg", "npereira");

}

//eventos de click
function eventosDeClick() {
     $("#btnLogin").click(verificar);
     $("#btnLogout").click(interfazUsuarioFinal);
     $("#btnReceta").click(tomarDatosRecetas);
     $("#btnColaborador").click(tomarDatosColaboradores)
     $("#listaIngresarColaboradores").click(mostrarIngresosDeNuevosColaboradores)
     $("#listaRecetas").click(mostrarIngresosDeRecetas)
     $("#actDesColaboradores").click(habilitarYDeshabilitarColaboradores);
     $("#reportesRecetas").click(reportesDeRecetas);
     $("#btnReportesPorTiempo").click(reportesPorTiempo);
     $("#btnMayorTiempo").click(reportesMayorTiempo);
     $("#btnPuntuacion").click(reportesPuntuacion);
     $("#btnBuscarUsuarioFinal").click(buscarRecetasParaUsuario)
}










//INTERFAZES DE USUARIO (MOSTRAR Y ESCONDER)//

// vista del usuario final en la pagina
function interfazUsuarioFinal() {

     $("#botoneraAdministrador").hide();
     $("#login").show();
     $("#campoDeBusqueda").show();
     $("#muro").show();
     $("#ingresarRecetas").hide()
     $("#btnLogout").hide()
     $("#ingresarColaboradores").hide()
     $("#listaColaboradores").hide();
     $("#reportes").hide();
     $("#muroReportes").hide();

     if (logeado != null) {
          alert("Hasta pronto " + logeado.nombre + " " + logeado.apellido);
          busquedasConBotonesAprobacion = 0;
          $("#txtUser").val(null);
          $("#txtPass").val(null);
     }
     logeado = null;
     mostrarRecetas(recetas);
}
//vista del administrador en la pagina
function interfazAdministrador() {

     $("#botoneraAdministrador").show();
     $("#login").hide();
     $("#campoDeBusqueda").hide();
     $("#muro").hide();
     $("#ingresarRecetas").show();
     $("#btnLogout").show();


}

function mostrarIngresosDeNuevosColaboradores() {
     $("#ingresarRecetas").hide();
     $("#ingresarColaboradores").show();
     $("#listaColaboradores").hide();
     $("#reportes").hide();
     $("#muroReportes").hide();

}

function mostrarIngresosDeRecetas() {
     $("#ingresarRecetas").show()
     $("#ingresarColaboradores").hide()
     $("#listaColaboradores").hide();
     $("#reportes").hide();
}

function habilitarYDeshabilitarColaboradores() {
     $("#ingresarRecetas").hide();
     $("#ingresarColaboradores").hide();
     $("#listaColaboradores").show(mostrarColaboradores);
     $("#reportes").hide();
     $("#muroReportes").hide();
}
function reportesDeRecetas() {
     $("#ingresarColaboradores").hide();
     $("#ingresarRecetas").hide();
     $("#listaColaboradores").hide();
     $("#reportes").show();
     $("#muroReportes").show();

}

//vista del colaborador en la pagina
function interfazColaborador() {
     $("#botoneraAdministrador").hide();
     $("#login").hide();
     $("#campoDeBusqueda").hide();
     $("#muro").hide();
     $("#ingresarRecetas").show()
     $("#btnLogout").show()
     $("#ingresarColaboradores").hide()
     $("#listaColaboradores").hide();
     $("#reportes").hide();
     $("#muroReportes").hide();
}








//INGRESAR AL SISTEMA COMO ADMINISTRADOR O COLABORADOR//


//inicio de sesion 
function verificar() {
     let usuario = $("#txtUser").val();
     let pass = $("#txtPass").val();
     if (usuario == admin.username && pass == admin.pass) {
          alert(`Bienvenid@ ${admin.nombre} ${admin.apellido}`)
          interfazAdministrador();
          logeado = admin
     }
     else {
          let usu = verificarColaborador(usuario, pass);
          if (usu != null) {
               alert(`Bienvneid@ ${usu.nombre} ${usu.apellido}`)
               logeado = usu;
               interfazColaborador();
          }
          if (usu == null) {
               alert(`Nombre de usuario y contraseña no validas`)
          }

     }

}

//verificar identidad del colaborador en el inicio de sesion
function verificarColaborador(u, p) {
     let retorno = null;
     for (let i = 0; i < colaboradores.length; i++) {
          if (u == colaboradores[i].username && p == colaboradores[i].pass && colaboradores[i].estado == true) {
               interfazColaborador();
               retorno = colaboradores[i];

          }


     }
     return retorno
}








//COMO CREAR RECETAS//


// tomar datos de las recetas //
function tomarDatosRecetas() {
     let titulo = $("#txtTitulo").val();
     let tiempo = $("#txtTiempo").val();
     let resenia = $("#txtResenia").val();
     let imagen = $("#flImagen").val().replace('C:\\fakepath\\', '')

     if (titulo == "") {
          alert("No se ah ingresado un titulo a la receta");

     }

     if (tiempo == "") {
          alert("No se ah ingresado un tiempo a la receta");

     }
     else if ($.isNumeric(tiempo)== false){
          alert("El tiempo ingresado debe ser un valor numerico");
     }

     if (resenia == "") {
          alert("No se ah ingresado una reseña a la receta");

     }

     if (imagen == "") {
          alert("No se ah seleccionado una imagen a la receta");

     }
     if (titulo == "" || tiempo == "" || resenia == "" || imagen == "" || $.isNumeric(tiempo)== false) {
          alert("intente nuevamente")
     }
     if (titulo != "" && tiempo != "" && resenia != "" && imagen != "" && $.isNumeric(tiempo)== true) {
          altaReceta(ultimoIdReceta, logeado.nombre + " " + logeado.apellido, titulo, tiempo, resenia, 0, 0, imagen, logeado.username);
          alert("Receta ingresada con exito");
     }
     $("#txtTitulo").val(null);
     $("#txtTiempo").val(null);
     $("#txtResenia").val(null);
     $("#flImagen").val(null);

}

// ingresar una receta al sistema
function altaReceta(unId, unAutor, unTitulo, unTiempo, unaResenia, contadorMeGusta, contadorNoMeGusta, unaImagen, unEscritor) {

     let nuevaReceta = new Receta(unId, unAutor, unTitulo, unTiempo, unaResenia, contadorMeGusta, contadorNoMeGusta, unaImagen, unEscritor);
     recetas.push(nuevaReceta);
     ultimoIdReceta++
     sumarReceta(unEscritor);
     return nuevaReceta;


}
// contador de recetas de cada colaborador
function sumarReceta(a) {
     for (let i = 0; i < colaboradores.length; i++) {
          if (colaboradores[i].username == a) {
               colaboradores[i].cantidadRecetas++;
          }
     }

}









//   COMO SE CREAN NUEVOS USUARIOS//


// toma los datos del html para crear nuevo colaborador
function tomarDatosColaboradores() {

     let nombre = $("#txtNombre").val();
     let apellido = $("#txtApellido").val();
     let username = generarUsuario(nombre, apellido);
     let pass = generarPass(nombre, apellido);
     let id = ultimoIdColaborador;
     let estado = true

     if (nombre == "") {
          alert("no se ah ingresado un nombre")
     }
     if (apellido == "") {
          alert("no se ah ingresado un apellido")
     }
     if (nombre == "" || apellido == "") {
          alert("intente nuevamente")
     }
     if (nombre != "" && apellido != "") {
          altaColaborador(nombre, apellido, username, pass, id, estado)
          alert("Colaborador ingresado con exito, con nombre de usuario: " + username + " y contraseña: " + pass);
          $("#txtNombre").val(null);
          $("#txtApellido").val(null);
     }
}

//generar colaborador a partir del nombre y apellido que el chef ingresa//
function generarUsuario(n, a) {
     let usuario;
     let primerLetraNombre = n.charAt(0).toLowerCase();
     a = a.toLowerCase();
     usuario = primerLetraNombre + a;

     if (existeUsuario(usuario) == false) {
          return usuario;

     }
     else {
          let i = 1

          let nuevoNombreUsuario = usuario + i;
          while (existeUsuario(nuevoNombreUsuario) == true) {
               i++
               nuevoNombreUsuario = usuario + i;

          }

          return nuevoNombreUsuario;
     }
}

//corroborar si el nombre de usuario ya existe ( sub funcion de generarUsuario )//
function existeUsuario(unUsuario) {
     let retorno = false

     for (let i = 0; i < colaboradores.length; i++) {
          if (colaboradores[i].username == unUsuario) {
               retorno = true;
               break;
          }
     }
     return retorno;

}

//generar contraseña para el colaborador ingresado a partir del nombre y apellido que el chef ingresa
function generarPass(n, a) {
     let pass;
     let primerLetraNombre = n.charAt(0).toLowerCase();
     a = a.toLowerCase();
     pass = primerLetraNombre + "-" + a;
     return pass;


}

// ingresar un colaborador al sistema
function altaColaborador(unNombre, unApellido, unUsername, unPass, unId, unEstado, unaCantidad) {
     let nuevoColaborador = new Colaborador(unNombre, unApellido, unUsername, unPass, unId, unEstado, unaCantidad);
     colaboradores.push(nuevoColaborador);
     ultimoIdColaborador++;
     return nuevoColaborador;
}




// MOSTRAR RECETAS PARA USUARIO FINAL

//carga de recetas en pantalla del usuario final


function mostrarRecetas(recetas) {
     recetas.sort(ordenarPorChef)
     $("#muro").html("");
     for (let i = 0; i < recetas.length; i++) {

          if (recetas[i].escritor == "chef") {

               $("#muro").append(`<div>
           <h2>${recetas[i].titulo}</h2>
           <h4>${recetas[i].autor}</h4>
           <img src="../Obligatorio programacion/img/${recetas[i].imagen}"> 
           <p class="duracion"><strong>${recetas[i].tiempo}</strong> minutos</p>
           <p>
           ${recetas[i].resenia}
           </p>
           <p class="likes">
             ${recetas[i].positivo} 
             <button id="btnMg${recetas[i].id}"><img src="http://chefblog.develotion.com/like.png"></button>
             |
             <button id="btnNg${recetas[i].id}"> <img src="http://chefblog.develotion.com/dislike.png"> </button>
             ${recetas[i].negativo} 
           </p>
         
           <hr>
         </div>`)
               $(`#btnMg${recetas[i].id}`).click(sumarMeGusta)
               $(`#btnNg${recetas[i].id}`).click(sumarNoMeGusta)

          }
     }
     for (let i = 0; i < recetas.length; i++) {
          let corroborar = estadoposteador(recetas[i].escritor);

          if (corroborar == true) {

               $("#muro").append(`<div>
          <h2>${recetas[i].titulo}</h2>
          <h4>${recetas[i].autor}</h4>
          <img src="../Obligatorio programacion/img/${recetas[i].imagen}"> 
          <p class="duracion"><strong>${recetas[i].tiempo}</strong> minutos</p>
          <p>
          ${recetas[i].resenia}
          </p>
          <p class="likes">
            ${recetas[i].positivo} 
            <button id="btnMg${recetas[i].id}"><img src="http://chefblog.develotion.com/like.png"></button>
            |
            <button id="btnNg${recetas[i].id}"> <img src="http://chefblog.develotion.com/dislike.png"> </button>
            ${recetas[i].negativo} 
          </p>
        
          <hr>
        </div>`)
               $(`#btnMg${recetas[i].id}`).click(sumarMeGusta)
               $(`#btnNg${recetas[i].id}`).click(sumarNoMeGusta)

          }
     }
}



//verificar estado del usuario//
function estadoposteador(a) {
     let retorno;
     for (let i = 0; i < colaboradores.length; i++) {
          if (a == colaboradores[i].username) {
               retorno = colaboradores[i].estado;
          }

     }
     return retorno;
}

//ordenar por chef

function ordenarPorChef(a, b) {


     if (a.autor > b.autor) {
          return 1;
     } if (a.autor < b.autor) {
          return -1;
     } else {
          return 0;
     }
}

//funciones me gusta y no me gusta
function sumarMeGusta() {

     let id = this.id
     let recetaBuscada = id.substring(5);

     for (let i = 0; i < recetas.length; i++) {
          if (recetas[i].id == recetaBuscada) {
               recetas[i].positivo++;

          }
     }
     mostrarRecetas(recetas)
     if (busquedasConBotonesAprobacion == 1) {
          mostrarRecetas(busquedasVieja)
     }
}
function sumarNoMeGusta() {
     let id = this.id
     let nombre = id.substring(5);

     for (let i = 0; i < recetas.length; i++) {
          if (recetas[i].id == nombre) {
               recetas[i].negativo++;
          }
     }
     mostrarRecetas(recetas)
     if (busquedasConBotonesAprobacion == 1) {

          mostrarRecetas(busquedasVieja)

     }
}




//COLABORADORES//

//Mostrar colaboradores


function mostrarColaboradores() {
     $("#listaColaboradores").html("");
     let largo = colaboradores.length
     for (let i = 0; i < largo; i++) {
          if (colaboradores[i].estado == true) {
               $("#listaColaboradores").append(`${colaboradores[i].nombre} ${colaboradores[i].apellido} ". Cantidad de recetas ("${colaboradores[i].cantidadRecetas}")     " <button id="habDes${colaboradores[i].id}">Deshabilitar</button><br>`)
               $(`#habDes${colaboradores[i].id}`).click(cambiarEstado);
          }
          else {
               $("#listaColaboradores").append(`${colaboradores[i].nombre} ${colaboradores[i].apellido} ". Cantidad de recetas ("${colaboradores[i].cantidadRecetas}")     " <button id="habDes${colaboradores[i].id}">Habilitar</button><br>`)
               $(`#habDes${colaboradores[i].id}`).click(cambiarEstado);
          }

     }


}
// habilitar y deshabilitar colaboradores
function cambiarEstado() {

     let id = this.id
     let colaboradorBuscado = id.substring(6);

     for (let i = 0; i < colaboradores.length; i++) {
          if (colaboradores[i].id == colaboradorBuscado) {
               if (colaboradores[i].estado == true) {
                    colaboradores[i].estado = false;
               }
               else {
                    colaboradores[i].estado = true;
               }

          }
     }

     mostrarColaboradores(colaboradores)

}





// REPORTES RECETAS//

//recetas por tiempo

function reportesPorTiempo() {

     ordenPorTiempo = recetas;
     ordenPorTiempo.sort(compararPorTiempo);
     let tiempoABuscar = parseInt($("#txtMinutos").val());
      if($.isNumeric(tiempoABuscar)== true){
     $("#muroReportes").html("");
     for (let i = 0; i < ordenPorTiempo.length; i++) {
          if (tiempoABuscar <= ordenPorTiempo[i].tiempo) {
               $("#muroReportes").append(`<div>
          <h2>${ordenPorTiempo[i].titulo}</h2>
          <h4>${ordenPorTiempo[i].autor}</h4>
          <img src="../Obligatorio programacion/img/${ordenPorTiempo[i].imagen}"> 
          <p class="duracion"><strong>${ordenPorTiempo[i].tiempo}</strong> minutos</p>
          <p>
          ${ordenPorTiempo[i].resenia}
          </p>
          <hr>
        </div>
        <br>`
               )
          }

     }
} else{
     alert("El tiempo a buscar debe ser un valor numerico")
}
     $("#txtMinutos").val(null);
}


function compararPorTiempo(a, b) {
     if (Number(a.tiempo) > Number(b.tiempo)) {
          return -1;
     } if (Number(a.tiempo) < Number(b.tiempo)) {
          return 1;
     } else {
          return 0;
     }

}

// mostrar recetas de mayor duracion
function reportesMayorTiempo() {
     let mayorTiempo = [];
     mayorTiempo = recetas.sort(compararPorTiempo);
     let duracion = mayorTiempo[0].tiempo
     $("#muroReportes").html("");
     for (let i = 0; i < mayorTiempo.length; i++) {
          if (duracion == mayorTiempo[i].tiempo) {
               $("#muroReportes").append(`<div>
          <h2>${mayorTiempo[i].titulo}</h2>
          <h4>${mayorTiempo[i].autor}</h4>
          <img src="../Obligatorio programacion/img/${mayorTiempo[i].imagen}"> 
          <p class="duracion"><strong>${mayorTiempo[i].tiempo}</strong> minutos</p>
          <p>
          ${mayorTiempo[i].resenia}
          </p>
          <hr>
        </div>
        <br>`
               )
          }

     }
}



// mostrar recetas por mayor rating
function reportesPuntuacion() {

     fijarPuntuacion(recetas);
     recetas.sort(compararPorRating)
     
     $("#muroReportes").html("");
     for (let i = 0; i < recetas.length; i++) {
          if ((recetas[i].positivo > 0 || recetas[i].negativo > 0) && recetas[0].rating == recetas[i].rating) {
               $("#muroReportes").append(`<div>
               <h1> Rating ${recetas[i].rating.toFixed(2)} %</h1>
          <h2>${recetas[i].titulo}</h2>
          <h4>${recetas[i].autor}</h4>
          <img src="../Obligatorio programacion/img/${recetas[i].imagen}"> 
          <p class="duracion"><strong>${recetas[i].tiempo}</strong> minutos</p>
          <p>
          ${recetas[i].resenia}
          </p>
          <hr>
        </div>
        <br>`
               )
          }
     }
}
function fijarPuntuacion(recetas) {

     for (let i = 0; i < recetas.length; i++) {
          (recetas[i].rating) = (recetas[i].positivo / (recetas[i].positivo + recetas[i].negativo)) * (100)

     }

}
function compararPorRating(a, b) {
     if (Number(a.rating) > Number(b.rating)) {
          return -1;
     } if (Number(a.rating) < Number(b.rating)) {
          return 1;
     } else {
          return 0;
     }

}




//BUSCADOR DE RECETAS PARA EL USUARIO//

     //buscador//
function buscarRecetasParaUsuario() {

     let textoABuscar = $("#txtBuscador").val();
     textoABuscar = textoABuscar.toLowerCase();
     textoABuscar = textoABuscar.trim();
     let z = quitarAcentos(textoABuscar);
     let vacio = false;
     if (textoABuscar == "") {
          vacio = true
     }

     for (i = 0; i < recetas.length; i++) {
          let x = quitarAcentos(recetas[i].titulo);
          x = x.toLowerCase();
          let y = quitarAcentos(recetas[i].resenia)
          y = y.toLowerCase();
          if (x.indexOf(z) != -1) {
               busquedas.push(recetas[i])
          }

          if (y.indexOf(z) != -1 && !(x.indexOf(z) != -1)) {
               busquedas.push(recetas[i]);
          }


     } if (busquedas == 0) {

          alert("No hay concidencias segun su criterio de busqueda, se recargaran todas las recetas");
          mostrarRecetas(recetas);
          busquedasConBotonesAprobacion = 0;

     }
     if (vacio == true) {
          alert("Su busqueda esta vacia , se recargaran todas las recetas");
          busquedas.splice(0);
          mostrarRecetas(recetas);
          busquedasConBotonesAprobacion = 0;

     }
     if (busquedas[0] != null) {
          alert("Se cargaron con exito sus resultados de busqueda")
          busquedasVieja.splice(0)
          pushArray(busquedas, busquedasVieja);
          mostrarRecetas(busquedas);
          busquedas.splice(0);
          busquedasConBotonesAprobacion = 1;
     }

     $("#txtBuscador").val(null);

}


//pushear un array en otro array 
function pushArray(a, b) {
     for (let i = 0; i < a.length; i++) {
          b.push(a[i]);
     }

}





// sacar los acentos de strings
function quitarAcentos(a) {
     return a.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
}

