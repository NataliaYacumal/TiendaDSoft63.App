const app = document.getElementById('typewriter');

const typewriter = new Typewriter(app, {
    loop: true,
    delay: 75
});

typewriter
.typeString('La mejor zona de la ciudad')
.pauseFor(200)
.start();