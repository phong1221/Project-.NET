window.ShowToast = (icon, message) => {
    Swal.fire({
        icon: icon, // 'success', 'error', 'warning', 'info'
        title: message,
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
};
