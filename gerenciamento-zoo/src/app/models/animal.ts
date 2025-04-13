import { Cuidado } from "./cuidado";

export interface Animal {
  id?: number;
  nome: string;
  descricao: string;
  dataNascimento: Date;
  especie: string;
  habitat: string;
  paisOrigem: string;
  cuidados: Cuidado[];
}
