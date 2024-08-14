var drawerSocial = new Drawer(document.getElementById('drawer-social'), {
	placement: 'right',
	backdrop: true,
	bodyScrolling: false,
	edge: false,
	edgeOffset: '',
	backdropClasses:
		'bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-30',
	onHide: () => {
		console.log('drawer is hidden');
		document.getElementById('drawer-social').classList.add("hidden")
	},
	onShow: () => {
		console.log('drawer is shown');
		document.getElementById('drawer-social').classList.remove("hidden")
	},
	onToggle: () => {
		console.log('drawer has been toggled');
		// document.getElementById('drawer-social').classList.toggle("hidden")
	},
}, {
	id: 'drawer-social',
	override: true
});

window.editSocialMediaLinks = {
	show() {
		drawerSocial.show()
	},
	hide() {
		drawerSocial.hide()
	}
}

var drawerLinks = new Drawer(document.getElementById('drawer-links'), {
	placement: 'right',
	backdrop: true,
	bodyScrolling: false,
	edge: false,
	edgeOffset: '',
	backdropClasses:
		'bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-30',
	onHide: () => {
		document.getElementById('drawer-links').classList.add("hidden")
	},
	onShow: () => {
		document.getElementById('drawer-links').classList.remove("hidden")
	},
	onToggle: () => {
		// console.log('drawer has been toggled');
		// document.getElementById('drawer-links').classList.toggle("hidden")
	},
}, {
	id: 'drawer-links',
	override: true
});

window.editOtherLinks = {
	show() {
		drawerLinks.show()
	},
	hide() {
		drawerLinks.hide()
	}
}
