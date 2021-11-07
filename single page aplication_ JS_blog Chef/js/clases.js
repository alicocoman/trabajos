class Administrador{
      constructor(unNombre,unApellido,unUsername,unPass){
            this.nombre = unNombre;
            this.apellido = unApellido;
            this.username = unUsername;
            this.pass = unPass ;       
            this.rol="admin"
      }
}
class Colaborador{
      constructor(unNombre,unApellido,unUsername,unPass, unId,unEstado){
            this.nombre = unNombre;
            this.apellido = unApellido;
            this.username = unUsername;
            this.pass = unPass ;
            this.id=unId;
            this.estado= unEstado ;
            this.rol = " usuario"
            this.cantidadRecetas = 0
      }
}
class Receta{
      constructor(unId, unAutor, unTitulo, unTiempo,unaResenia,contadorMeGusta,contadorNoMeGusta,unaImagen,unEscritor){
            this.id=unId;
            this.autor=unAutor;
            this.titulo=unTitulo;
            this.tiempo=unTiempo;
            this.resenia=unaResenia;
            this.positivo=contadorMeGusta;
            this.negativo=contadorNoMeGusta;
            this.imagen=unaImagen
            this.escritor = unEscritor
            this.rating = 0
      }
}