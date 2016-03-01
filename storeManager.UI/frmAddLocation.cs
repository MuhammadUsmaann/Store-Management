using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using BusinessLayer.Interfaces;
using BusinessLayer;
using storeManager.BusinessLayer;
using storeManager.Entities;

namespace storeManager.UI
{
    public partial class frmAddLocation : Telerik.WinControls.UI.RadForm
    {
        EntityState _entityState = EntityState.New;
        IErrorService _logger;

        public frmAddLocation()
        {
            InitializeComponent();

            _logger = new ErrorLogService();
            EventHub.Hub.GenericInfo += new EventHandler<EventHub.EventHubAgs>(Hub_GenericInfo);
        }

        public frmAddLocation(EntityState entityState)
        {
            InitializeComponent();

            _entityState = entityState;
            btnSave.Text = "Update";
            EventHub.Hub.GenericInfo += new EventHandler<EventHub.EventHubAgs>(Hub_GenericInfo);
        }

        //public EntityState State
        //{
        //    get
        //    {
        //        return _entityState;
        //    }
        //    set
        //    {
        //        value = _entityState;
        //    }
        //}

        public int LocationID { get; set; }

        void Hub_GenericInfo(object sender, EventHub.EventHubAgs e)
        {
            txtComment.Text = e.Data;
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            new frmDescription("frmAddLocation", txtComment.Text).ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_entityState)
                {
                    case EntityState.New:
                        new LocationService().Add(new Location { Name = txtName.Text, Comment = txtComment.Text });
                        break;
                    case EntityState.Dirty:
                        Location location = new Location
                        {
                            Id = LocationID,
                            Name = txtName.Text,
                            Comment = txtComment.Text
                        };
                        new LocationService().Update(location);
                        break;
                    default:
                        break;
                }

                Helper.ClearForm(this);
                btnSave.Text = "Save";
                _entityState = EntityState.New;
                Helper.ShowMessage("Location saved successfully", "Location Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSetupDetails frmSetup = Helper.CreateInstanceFor<frmSetupDetails>("frmSetupDetails");
                if (frmSetup != null)
                {
                    frmSetup.LoadGridWithDataDatasource(() => new LocationService().GetAll());
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmAddLocation", "btnSave");
                Helper.ShowMessage("Location was not saved successfully \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddLocation_Load(object sender, EventArgs e)
        {
            if (_entityState == EntityState.Dirty)
            {
                Location loacation = new LocationService().GetSingle(new Location { Id = LocationID });
                txtName.Text = loacation.Name;
                txtComment.Text = loacation.Comment;
            }
        }
    }
}
