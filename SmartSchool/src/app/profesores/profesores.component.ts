import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Profesor } from '../models/profesor';
import { ProfesorService } from './profesor.service';
 
@Component({
  selector: 'app-profesores',
  templateUrl: './profesores.component.html',
  styleUrls: ['./profesores.component.css']
})
export class ProfesoresComponent implements OnInit {

  public modalRef: BsModalRef;
  public profesorForm: FormGroup;
  public titulo = 'Profesores';
  public profesorSeleccionado: Profesor;
  public modo= 'post';

  public profesores: Profesor[];

    openModal(template: TemplateRef<any>){
      this.modalRef = this.modalService.show(template);
    }
  
    constructor(private fb: FormBuilder,
                private modalService: BsModalService,
                private profesorService: ProfesorService) 
    {
      this.crearFormulario();
    }

  regresar(){
    this.profesorSeleccionado = null;
  }

  ngOnInit() {
    this.cargarProfesores();
  }

  crearFormulario(){
    this.profesorForm = this.fb.group({
      id:[''],
      nombre: ['', Validators.required]
    });
  }

  guardarProfesor(profesor: Profesor){
    (profesor.id == 0) ? this.modo='post':this.modo = 'put';
    this.profesorService[this.modo](profesor).subscribe(
      (model: Profesor) => {
        console.log(model);
        this.cargarProfesores();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  profesorSubmit(){
    this.guardarProfesor(this.profesorForm.value);
  }

  profesorSelect(profesor: Profesor){
    this.profesorSeleccionado = profesor;
    this.profesorForm.patchValue(profesor);
  }

  profesorNuevo(){
    this.profesorSeleccionado = new Profesor;
    this.profesorForm.patchValue(this.profesorSeleccionado);
  }

  cargarProfesores(){
    this.profesorService.getAll().subscribe(
      (profesores: Profesor[]) => {
        this.profesores = profesores;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

}
