var element = document.getElementsByClassName('button menu-item');

for (var i = 0; i < element.length; i++) {
  element[i].addEventListener('mouseenter', showSub, false)
  element[i].addEventListener('mouseleave', hideSub, false)
}

function showSub() {
  if (this.children.length > 0) {
    for (var i = 0; i < this.children.length; i++) {
      this.children[i].style.height = "auto";
      this.children[i].style.opacity = "1";
      this.children[i].style.overflow = "visible";
      this.children[i].style.transition = "all 0.5s ease -in";
    }
  }
  else {
    return false;
  }
}

function hideSub() {
  if (this.children.length > 0) {
    for (var i = 0; i, this.children.length; i++) {
      this.children[i].style.height = "0";
      this.children[i].style.opacity = "0";
      this.children[i].style.overflow = "hidden";
    }
  }
  else {
    return false;
  }
}

var elementSub = document.getElementsByClassName('button submenu');

for (var i = 0; i < element.length; i++) {
  element[i].addEventListener('mouseenter', showButton, false)
  element[i].addEventListener('mouseleave', hideButton, false)
}

function showButton() {
  if (this.children.length > 0) {
    for (var i = 0; i < this.children.length; i++) {
      this.children[i].style.display = "block";
    }
  }
  else {
    return false;
  }
}

function hideButton() {
  if (this.children.length > 0) {
    for (var i = 0; i, this.children.length; i++) {
      this.children[i].style.display = "none";
    }
  }
  else {
    return false;
  }
}