﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _apellido;
        private string _direccion;
        private string _email;
        private DateTime _fechaNacimiento;
        private int _idPlan;
        private int _legajo;
        private string _nombre;
        private string _telefono;
        private int _tipoPersona;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public int IdPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }
        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public int TipoPersona
        {
            get { return _tipoPersona; }
            set { _tipoPersona = value; }
        }
    }
}