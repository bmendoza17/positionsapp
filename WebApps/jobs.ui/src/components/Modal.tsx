import { useNavigate } from 'react-router-dom';
import { ReactNode } from 'react';

function Modal({ children }: { children: ReactNode }) {
    const navigate = useNavigate();

    function onCloseHandler() {
        navigate(-1);
    }

    return <>
        <div onClick={onCloseHandler}></div>
        <dialog open>
            {children}
        </dialog>
    </>
}

export default Modal;