using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClinica
{
    public partial class FrmRecordatorio : Form
    {
        CancellationTokenSource source;
        CancellationToken token;
        public delegate void DelegadoNotificacion();
        public DelegadoNotificacion notificacionFin;
        public delegate void NotificarRecordatorio(DateTime fechaANotificar);

        public event NotificarRecordatorio RecordatorioTurno;
        public event Action? ActualizarTablas;

        public FrmRecordatorio()
        {
            InitializeComponent();
            source = new CancellationTokenSource();
            token = source.Token;
            notificacionFin = MostrarAlertaFin;
            notificacionFin += ReiniciarEnvioDeRecordatorio;

            RecordatorioTurno += Clinica.Notificar;

        }

        private void FrmRecordatorio_Load(object sender, EventArgs e)
        {
            pbRecordatorio.Value = 0;

            Task tarea = Task.Run(() =>
            {
                EnvioRecordatorios(token);

            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            source.Cancel();
            ReiniciarEnvioDeRecordatorio();
        }

        /// <summary>
        /// Informa a través de una alerta que se ha enviado el recordatorio
        /// Este método se suscribe en el delegado notificacionFin
        /// </summary>
        private void MostrarAlertaFin()
        {
            MessageBox.Show("Recordatorios enviados", "Éxito", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Envia los recordatorios a los turnos del día siguiente
        /// Hará avanzar la barra de progreso al menos que se presione el boton cancelar.       
        /// Seteará propiedad recordatorioNotificado de los turnos afectados en true
        /// </summary>
        /// <param name="token"></param>
        private void EnvioRecordatorios(CancellationToken token)
        {
            while (pbRecordatorio.Value < 100)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                seteoEstadoRecordatorio();
                Thread.Sleep(1000);
            }

            RecordatorioTurno.Invoke(DateTime.Now.AddDays(1));

            if (ActualizarTablas is not null)
            {
                ActualizarTablas.Invoke();
            }
            notificacionFin.Invoke();

        }

        /// <summary>
        /// Setea el valor de la barra de progreso en 0
        /// Este metodo se suscribe en el delegado notificarFin
        /// </summary>
        private void ReiniciarEnvioDeRecordatorio()
        {
            if (this.InvokeRequired)
            {
                Action delegado = ReiniciarEnvioDeRecordatorio;
                this.Invoke(delegado);
            }
            else
            {
                pbRecordatorio.Value = 0;
                this.Close();
            }
        }

        /// <summary>
        /// Setea el estado de la barra de progreso de 10 en 10
        /// </summary>
        private void seteoEstadoRecordatorio()
        {

            if (pbRecordatorio.InvokeRequired)
            {
                Action delegado = seteoEstadoRecordatorio;
                pbRecordatorio.Invoke(delegado);
            }
            else
            {
                pbRecordatorio.Value += 10;
            }
        }

    }
}
