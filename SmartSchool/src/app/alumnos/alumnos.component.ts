import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Alumno } from '../models/alumno';
import { AlumnoService } from './alumno.service';

@Component({
  selector: 'app-alumnos',
  templateUrl: './alumnos.component.html',
  styleUrls: ['./alumnos.component.css']
})
export class AlumnosComponent implements OnInit {

  public modalRef: BsModalRef;
  public alumnoForm: FormGroup;
  public titulo = 'Alumnos';
  public alumnoSeleccionado: Alumno;
  public textSimple: string;
  public modo= 'post';

  public alumnos : Alumno[];


  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder, 
              private modalService: BsModalService,
              private alumnoService: AlumnoService) { 
    this.crearFormulario();
  }

  ngOnInit() {
    this.cargarAlumno();
  }

  cargarAlumno(){
    this.alumnoService.getAll().subscribe(
      (alumnos:Alumno[]) => {
        this.alumnos = alumnos;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  crearFormulario(){
    this.alumnoForm = this.fb.group({
      id:[''],
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      matricula: ['', Validators.required]
    });
  }

  guardarAlumno(alumno: Alumno){
    (alumno.id == 0) ? this.modo='post':this.modo = 'put';
    this.alumnoService[this.modo](alumno).subscribe(
      (model: Alumno) => {
        console.log(model);
        this.cargarAlumno();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  eliminarAlumno(id:number){
    this.alumnoService.delete(id).subscribe(
      (model:any) =>{
        console.log(model);
        this.cargarAlumno();
      },
      (error: any) => {
        console.error(error);
      }
    )
  }

  alumnoSubmit(){
    this.guardarAlumno(this.alumnoForm.value);
  }

  alumnoSelect(alumno: Alumno){
    this.alumnoSeleccionado = alumno;
    this.alumnoForm.patchValue(alumno);
  }

  alumnoNuevo(){
    this.alumnoSeleccionado = new Alumno();
    this.alumnoForm.patchValue(this.alumnoSeleccionado);
  }

  regresar(){
    this.alumnoSeleccionado = null;
  }
}
