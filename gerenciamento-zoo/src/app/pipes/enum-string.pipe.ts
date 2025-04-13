import { Pipe, PipeTransform } from '@angular/core';
import { UnidadeFrequenciaEnum } from '../models/enum/UnidadeFrequenciaEnum';

@Pipe({
  name: 'enumString'
})
export class EnumStringPipe implements PipeTransform {

  transform(value: number): string {
    return UnidadeFrequenciaEnum[value] ?? 'Desconhecido';
  }
}
