poppy.pop('success', "Success", 'You have successfully logged in');
poppy.pop('info', "Did you know...?", 'Nakov is only 22 years old!');
poppy.pop('error', "Error", 'Invalid username/password');
poppy.pop('warning', 'Attention!', 'You are our 100th visitor.', redirect);

function redirect() {
    window.location = 'https://www.youtube.com/watch?v=HMUDVMiITOU';
}
