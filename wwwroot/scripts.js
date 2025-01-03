
function reportViolation(activity) {
    fetch('http://localhost:5000/api/home/report', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ activity: activity, timestamp: new Date().toISOString() })
    })
        .then(response => {
            if (!response.ok) throw new Error('Failed to report violation');
            return response.json();
        })
        .then(data => console.log('✅ Báo cáo vi phạm:', data))
        .catch(err => console.error('❌ Lỗi báo cáo:', err));
}
// Chặn chuột phải
document.addEventListener('contextmenu', function (e) {
    e.preventDefault();
    alert('Chuột phải đã bị vô hiệu hóa trên trang này.');
});


// Chặn phím tắt nguy hiểm
document.addEventListener('keydown', event => {
    if (event.ctrlKey && (event.key === 'u' || event.key === 'U' || event.key === 's' || event.key === 'S' || event.key === 'c' || event.key === 'C' || event.key ==='v' ||  event.key ==='V')) {
        event.preventDefault();
        alert('Hành động này đã bị chặn.');
    }

    if (event.key === 'F12' || (event.ctrlKey && event.shiftKey && event.key === 'I')) {
        event.preventDefault();
        sendViolationLog('Attempted to open developer tools.');
    }
});

document.addEventListener('visibilitychange', function () {
    if (document.hidden) {
        alert('Bạn đã chuyển tab! Hãy quay lại trang để tiếp tục.');
    }
});

window.addEventListener('focus', () => {
    console.log('Cửa sổ được focus');
});

window.addEventListener('blur', () => {
    reportViolation('Người dùng rời khỏi cửa sổ');
});

document.addEventListener('DOMContentLoaded', () => {
    if (!document.fullscreenElement) {
        document.documentElement.requestFullscreen();
    }
});


// Phát hiện rời khỏi trang web
window.addEventListener('blur', () => {
    sendViolationLog('User switched to another application or tab.');
});

// Gửi log vi phạm về server
function sendViolationLog(message) {
    fetch('/api/log/violation', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ violation: message })
    }).catch(error => console.error('Failed to send violation log:', error));
}
