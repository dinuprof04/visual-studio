// Simple left-right animation using requestAnimationFrame for smoothness.
const ball = document.getElementById('ball');

let x = 0;
let vx = 2.5;  // px/frame
let minX = 0;
let maxX;

function measure() {
    const stage = ball.parentElement.getBoundingClientRect();
    maxX = Math.max(0, stage.width - ball.offsetWidth);
    x = Math.max(minX, Math.min(x, maxX));
}
measure();
addEventListener('resize', measure);

function animate() {
    x += vx;
    if (x <= minX) { x = minX; vx = Math.abs(vx); }
    else if (x >= maxX) { x = maxX; vx = -Math.abs(vx); }
    ball.style.transform = `translate(${x}px, -50%)`;
    requestAnimationFrame(animate);
}
requestAnimationFrame(animate);
