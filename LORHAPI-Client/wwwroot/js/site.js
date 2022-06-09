var slider = document.getElementById('slider');

noUiSlider.create(slider, {
    start: [15, 100],
    connect: true,
    range: {
        'min': 15,
        'max': 100
    }
});
