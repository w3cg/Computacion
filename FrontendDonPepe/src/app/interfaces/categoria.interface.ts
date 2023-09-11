export interface Categoria {
  idCategoria: number;
  codigo: string;
  nombre: string;
}

export interface CategoriaRequest {
  pCodigo: string;
  pNombre: string;
  ppage: number;
  pcount: number;
}

export interface AgregarCategoriaRequest {
  codigo: string;
  nombre: string;
}

export interface EditarCategoriaRequest {
  idCategoria: number;
  nombre: string;
}

export interface EliminarCategoriaRequest {
  idCategoria: number;
}
