import { BaseEntity, Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class Save extends BaseEntity {
  @PrimaryGeneratedColumn()
  id!: number;

  @Column()
  uniqueId: string;

  @Column()
  level: number;
}
