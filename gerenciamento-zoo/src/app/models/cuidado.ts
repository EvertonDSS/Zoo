import { UnidadeFrequenciaEnum } from "./enum/UnidadeFrequenciaEnum";

export interface Cuidado {
  id: number;
  nomeCuidado: string;
  descricao: string;
  frequencia: number;
  unidadeFrequencia: UnidadeFrequenciaEnum
}